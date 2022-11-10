using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ApoointmentsDto
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int IndividualId { get; set; }
        public DateTime DateOfReservation { set; get; }
        public int Status { get; set; }
        public string ClerckName { set; get; }
        public string EmployeeForServiceName { set; get; }
        public string ServiceName { set; get; }
        public string IndividualName { get; set; }
        public int EmployeeForServiceId { get; set; }
    }
}
