using BackEnd;
using BackEnd.Entities;
using Dto.ViewDto;
using IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    public class DoctorController : Controller
    {
        public EmployeeIRepo employeeIRepo;
        public AppointmentIRepo appointmentIRepo;
        public UserManager<User> userManager;
        public ApplicationDBContext context;

        public DoctorController(EmployeeIRepo employeeIRepo, AppointmentIRepo appointmentIRepo, UserManager<User> usersManager, ApplicationDBContext cotext)
        {
            this.employeeIRepo = employeeIRepo;
            this.appointmentIRepo = appointmentIRepo;
            this.userManager = usersManager;
            this.context = cotext;
        }
        public async Task<IActionResult> Index()
        {
           var user= await userManager.GetUserAsync(User);
          
            DoctorDto dto = new DoctorDto();
            dto.nextAppointment = appointmentIRepo.GetNextAppointment(context,user.Id,employeeIRepo);
            return View(dto);
        }
        public IActionResult Queue(int employeeId)
        {
            QueueDto dto = new QueueDto();
            dto.AppointmentsInQueue = appointmentIRepo.GetEmployeeQueue(context, employeeId);
            dto.employeeId = employeeId;
            return View(dto);
        }
        public IActionResult medicin()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> GetNextAppointment()
        {
            var user = await userManager.GetUserAsync(User);
            var result = appointmentIRepo.GetNextAppointment(context, user.Id, employeeIRepo);
            
            return Ok(result);
        }
    }
}
