using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class Preview
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }

        public int DoctorId { get; set; }
        public Employee doctore { get; set; }

        public int IndividialId { get; set; }   
        public Individual individual { get; set; }


    }
}
