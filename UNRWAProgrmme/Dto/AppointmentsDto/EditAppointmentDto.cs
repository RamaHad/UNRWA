using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.AppointmentsDto
{
    public class EditAppointmentDto
    {
        public DateTime NewDate { get; set; }
        public int NewServiceId { get; set; }
        public int NewTimeSlotId { get; set; }
        public int EditAppointmentId { set; get; }
        public int EditAppointmentIndividualId { set; get; }
        public int NewClerckId { get; set; }
        public int NewEmployeeForServiceId { get; set; }
    }
}
