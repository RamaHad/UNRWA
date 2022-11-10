using BackEnd;
using BackEnd.Entities;
using Dto.AppointmentsDto;
using Dto.IndividualDto;
using Dto.ViewDto;
using IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Authorize]
    public class ClerckController : Controller
    {
      
        private readonly IndividualIRepo _individiualRepo;
        private readonly AppointmentIRepo _appointmentIRepo;
        private readonly ServiceIRepo _serviceIRepo;
        private readonly TeamIRepo _teamIRepo;
        private readonly EmployeeIRepo _employeeIRepo;
        private readonly UserManager<User> _userManager;
        private readonly TimeSloteIRepo _timeSloteRepo;
        private readonly StudyLevelIRepo _studyLevelIRepo;
        private readonly RelationshipIRepo _relationshipIRepo;
        public ClerckController(TimeSloteIRepo timeSloteRepo, IndividualIRepo individiualRepo, AppointmentIRepo appointmentIRepo, ServiceIRepo serviceIRepo, TeamIRepo teamIRepo, EmployeeIRepo employeeIRepo, UserManager<User> userManager, StudyLevelIRepo studyLevelIRepo, RelationshipIRepo relationshipIRepo)
        {
            _timeSloteRepo = timeSloteRepo;
            _individiualRepo = individiualRepo;
            _appointmentIRepo = appointmentIRepo;
            _serviceIRepo = serviceIRepo;
            _teamIRepo = teamIRepo;
            _employeeIRepo = employeeIRepo;
            _userManager = userManager;
            _studyLevelIRepo = studyLevelIRepo;
            _relationshipIRepo = relationshipIRepo;
        }

        public IActionResult Index()
        {
            SearchDto dto = new SearchDto();

            //initialize dto to search by family card
            dto.individualDtos = new List<IndividualDto>();

            //initialize dto to search by individualID
            dto.individualDto = new IndividualDto();
            return View(dto);
        }

        //naming section
        public IActionResult Naming(int individualId)
        {
            var namingDto = _individiualRepo.GetInfoToEdit(individualId);
            namingDto.studeyLevels= _studyLevelIRepo.GetStudyLevels();
            namingDto.relatioships = _relationshipIRepo.GetRelationships();
            return View(namingDto);
        }
        [HttpPost]
        public IActionResult EditIndividual(NamingDto model)
        {
          
                EditIndividualDto dto = new EditIndividualDto();
                dto.IndividualId = model.IndividualId;
                dto.RelationShipId = model.NewRelationshipId;
                dto.PhoneNumber = model.PhoneNumber;
                dto.StudyLevelId = model.NewStudyLevelId;
                dto.Gender = model.Gender;
                dto.MaritalStatus = model.MaritalStatus;
            if (model.Naming!=null){
                dto.Naming = model.Naming;
            }
            else
            {
                dto.Naming = " ";
            }

                var result =_individiualRepo.EditIndividual(dto);
                if(result)
                {
                    TempData["EditIndividualSuccess"] = "Individual Edit is Successfully !";
                    return Redirect("~/Clerck/Naming?individualId=" + model.IndividualId);
                }
                else
                {
                    TempData["EditIndividualFaild"] = "Individual Edit is Faild !";
                    return Redirect("~/Clerck/Naming?individualId=" + model.IndividualId);
            }




        }
        //end naming section




       public IActionResult ManageAppointment(int individiualId)
        {
            ManageAppointmentDto dto = new ManageAppointmentDto();   //initialize view dto
            dto.individualId = individiualId; // save individualId to use it in this view
            var result = _appointmentIRepo.GetIndividualAppointments(individiualId); // get all this individual appointments
            if (result == null) return NotFound(" Sorry Individual Not Found!"); // if there is error in individualId
            else dto.Appointments = result;
            dto.Services =  _serviceIRepo.ClerckService(); // initialize services for the clerck
            dto.Teams = _teamIRepo.GetTeams(); //initialize teams
            //dto.TimeSlotes = _timeSloteRepo.GetTimeSlote(); //initialize time
            return View(dto);
        }   

       
        //calling from ajax
        public IActionResult GetHealthProvider(int teamId)
        {
             var result =  _employeeIRepo.GetEmployeesByTeamId(teamId);
             return Ok(result);
        }
        [HttpPost]
        public IActionResult GetAvaliabelTimeSlote(ManageAppointmentDto date)
        {
            var result = _timeSloteRepo.GetAvaliableSlote(date.AppointmentDate, date.AoppointmentproviderId);
            return Ok(result);
        }


        public IActionResult? DeleteAppointment(ManageAppointmentDto dto)
        {
            var result = _appointmentIRepo.DeleteAppointment(dto.AppointmetId);
            if (result == true)
            {
                TempData["SuccessDeleteAppointmet"] = "Appointment is Deleted successfully!";

                return Redirect("~/Clerck/ManageAppointment?individiualId=" + dto.individualId);
            }
            else
            {
                TempData["FaildDeleteAppointmet"] = " Delete Appointment is  Faild!";

                return Redirect("~/Clerck/ManageAppointment?individiualId=" + dto.individualId);
            }
        }

        [HttpPost]
        public IActionResult AddAppointment(ManageAppointmentDto dto)
        {
            dto.addAppointmentDto.EmployeeForServiceId = dto.AoppointmentproviderId;
            dto.addAppointmentDto.IndividualId = dto.individualId;
            dto.addAppointmentDto.TimeSloteId = dto.TimeSloteId;
            dto.addAppointmentDto.DateOfReservation = dto.AppointmentDate;
            var result = _appointmentIRepo.AddAppointment(dto.addAppointmentDto);//to do
            if (result == true)
            {
                TempData["SuccessAddAppointmet"] = "Appointment is added successfully!";
                return Redirect("~/Clerck/ManageAppointment?individiualId=" + dto.individualId);
            }
            else
            {
                TempData["FaildAddAppointmet"] = " add appointment is faild!";
                return Redirect("~/Clerck/ManageAppointment?individiualId=" + dto.individualId);
            }

        }
        [HttpPost]
        public IActionResult EditAppointment(ManageAppointmentDto dto)
        {
            EditAppointmentDto newAppointment = new EditAppointmentDto();
            newAppointment.EditAppointmentId=dto.EditAppointmentId;
            newAppointment.NewEmployeeForServiceId = dto.NewProviderId;
            newAppointment.EditAppointmentIndividualId= dto.EditAppointmentIndividualId;
            newAppointment.NewTimeSlotId = dto.NewTimeSlotId;
            newAppointment.NewDate = dto.NewDate;
            newAppointment.NewServiceId= dto.NewServiceId;
            
            var result = _appointmentIRepo.EditAppointment(newAppointment);//to do
            if (result == true)
            {
                TempData["SuccessEditAppointmet"] = "Appointment is Edit successfully!";
                return Redirect("~/Clerck/ManageAppointment?individiualId=" + dto.EditAppointmentIndividualId);
            }
            else
            {
                TempData["FaildEditAppointmet"] = " Edit appointment is faild!";
                return Redirect("~/Clerck/ManageAppointment?individiualId=" + dto.EditAppointmentIndividualId);
            }

        }

        [HttpPost]
        public IActionResult AddQuickAppointment(ManageAppointmentDto dto)  //with status = 2
        {
            dto.addQuickAppointmentDto.EmployeeForServiceId = dto.QuickAoppointmentproviderId;
            dto.addQuickAppointmentDto.IndividualId = dto.individualId;
            dto.addQuickAppointmentDto.Status = 2;
            var result = _appointmentIRepo.AddQuickAppointment(dto.addQuickAppointmentDto);
            if(result == true)
            {
                TempData["SuccessAddQuickAppointmet"] = "Quick Appointment is added successfully!";
                return Redirect("~/Clerck/ManageAppointment?individiualId=" + dto.individualId);
            }
            else
            {
                TempData["FaildAddQuickAppointmet"] = "Add Quick Appointment is faild!";
                return Redirect("~/Clerck/ManageAppointment?individiualId=" + dto.individualId);
            }
            
        }

        [HttpPost]
        public IActionResult SearchByFamilyCard(SearchDto dto)
        {
            
            dto.individualDtos = _individiualRepo.FindByFamilyCard(dto.familyCard);
            return View("Index",dto);
        }
        [HttpPost]
        public IActionResult SearchByIndividualId(SearchDto dto)
        {

            dto.individualDto = _individiualRepo.FindByIndividiualId(dto.IndividualId);

            //clear old search result in the view
            if(dto.individualDtos !=null)
            {
                dto.individualDtos.Clear();
            }
            else //add new search result to the view
            {
                dto.individualDtos = new List<IndividualDto>();
                dto.individualDtos.Add(dto.individualDto);
            }
            return View("Index", dto);
        }
        [HttpPost]
        public IActionResult SearchByNCDNumber(SearchDto dto)
        {

            dto.individualDto = _individiualRepo.FindByNCDNumber(dto.NCDNumber);

            //clear old search result in the view
            if (dto.individualDtos != null)
            {
                dto.individualDtos.Clear();
            }
            else //add new search result to the view
            {
                dto.individualDtos = new List<IndividualDto>();
                dto.individualDtos.Add(dto.individualDto);
            }
            return View("Index", dto);
        }
        [HttpPost]
        public IActionResult SearchByCHRNumber(SearchDto dto)
        {

            dto.individualDto = _individiualRepo.FindByCHRNumber(dto.CHRNumber);

            //clear old search result in the view
            if (dto.individualDtos != null)
            {
                dto.individualDtos.Clear();
            }
            else //add new search result to the view
            {
                dto.individualDtos = new List<IndividualDto>();
                dto.individualDtos.Add(dto.individualDto);
            }
            return View("Index", dto);
        }
      
    }
}
