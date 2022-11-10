using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ApoointmentsDto
{
    public  class AddQuickAppointmentDto
    {
        public int IndividualId { get; set; }
        public DateTime DateOfReservation { set; get; } = DateTime.Now;
        public int Status { get; set; }
        public int ClerckId { set; get; }
        public int EmployeeForServiceId { set; get; }
        [Display(Name = "The Service:")]
        [Required]
        public int ServiceId { set; get; }
       
    }
}
