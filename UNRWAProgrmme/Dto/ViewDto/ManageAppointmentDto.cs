using Dto.ApoointmentsDto;
using Dto.AppointmentsDto;
using Dto.EmployeesDto;
using Dto.ServicesDto;
using Dto.TeamsDto;
using Dto.TimeSlotesDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ViewDto
{
    public class ManageAppointmentDto
    {
        public int individualId { get; set; }
        public List<AppointmentDto> Appointments { get; set; }   
        public int AppointmetId { get; set; }
        [Display(Name ="The Team:")]
        [Required]
        public int AppointmentTeamId { get; set; }
        [Display(Name = "The Team:")]
        [Required]
        public int QuickAppointmentTeamId { get; set; }
        public List<ServiceDto> Services { get; set; } = new List<ServiceDto>();   
        public List<TeamDto> Teams { get; set; } = new List<TeamDto> ();
        public List<EmployeeDto> ServiceProvider { get; set; } = new List<EmployeeDto>();
        public AddQuickAppointmentDto addQuickAppointmentDto { get; set; } = new AddQuickAppointmentDto ();
        public AddAppointmentDto addAppointmentDto { get; set; } = new AddAppointmentDto();

        [Display(Name = "Health Care Provider:")]
        [Required]
        public int AoppointmentproviderId { get; set; }

        [Display(Name = "Health Care Provider:")]
        [Required]
        public int QuickAoppointmentproviderId { get; set; }

        public List<TimeSloteDto> TimeSlotes { get; set; } = new List<TimeSloteDto>();
        [Required]
        public int TimeSloteId { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }


        //for edit
        [Required]
        [Display (Name ="New Service")]
        public int NewServiceId { get; set; }
        [Required]
        [Display(Name = "New Team")]
        public int NewTeamId { get; set; }
        [Required]
        [Display(Name = "New Provider")]
        public int NewProviderId { get; set; }
        [Required]
        [Display(Name = "New Time")]
        public int NewTimeSlotId { get; set; }
        [Required]
        [Display(Name = "New Date")]
        public DateTime NewDate { get; set; }
        public int EditAppointmentId { set; get; }
        public int EditAppointmentIndividualId { set; get; }


    }
}
