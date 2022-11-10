using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.AppointmentsDto
{
    public class AddAppointmentDto
    {
        [Display (Name ="The Service:")]
        [Required]
        public int ServiceId { get; set; }
        public int EmployeeForServiceId { get; set; }
        public int IndividualId { get; set; }
        public DateTime DateOfReservation { set; get; }
        public int TimeSloteId { get; set; }
        public int Status { get; set; }
        public int ClerckId { set; get; }
    }
}
