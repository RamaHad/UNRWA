using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class Reservation
    {
        public int Id { set; get; }
        public DateTime DateOfReservation { set; get; }
        public int Status { get; set; }

        public int ClerickId { set; get; }
        public Employee clerick { set; get; }

        public int EmployeeForServiceId { get; set; }
        public Employee employeeForService { set; get; }

        public int ServiceId { set; get; }
        public Service service { set; get; }

        public int IndevisualId { get; set; }
        public Individual individual{ get; set;}

    }
}
