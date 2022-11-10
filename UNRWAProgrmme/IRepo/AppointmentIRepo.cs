using BackEnd;
using Dto.ApoointmentsDto;
using Dto.AppointmentsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface AppointmentIRepo
    {
        public List<AppointmentDto> GetIndividualAppointments(int individualId);
        public bool DeleteAppointment(int appointmentlId);
        public bool AddQuickAppointment(AddQuickAppointmentDto addQuickAppointmentDto);
        public bool AddAppointment(AddAppointmentDto addAppointmentDto);
        public bool EditAppointment(EditAppointmentDto editAppointmentDto);
        public AppointmentDto GetNextAppointment(ApplicationDBContext _context, string userId, EmployeeIRepo employeeIRepo);
        public List<AppointmentDto> GetEmployeeQueue(ApplicationDBContext _context, int employeeId);
    }
}
