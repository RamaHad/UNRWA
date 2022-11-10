using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class Employee
    {
        public int Id { get; set; } 
        public double Salary { get; set; }

        public int IndividualId { get; set; }
        public Individual individual { get; set; }

        public int TeamId { get; set; } 
        public Team team { get; set; }

        public int WorkId { get; set; }
        public Work work { get; set; }

        public int HealthCenterId { get; set; }
        public HealthCenter healthCenter { get; set; }
    }
}
