using Dto.ApoointmentsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dto.ViewDto
{
    public class DoctorDto
    {
        public AppointmentDto nextAppointment { get; set; } = new AppointmentDto();
        public int employeeId { get; set; }
    }
}
