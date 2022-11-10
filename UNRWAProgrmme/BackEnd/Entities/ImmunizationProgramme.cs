using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class ImmunizationProgramme
    {
        public int Id { get; set; }
        public string AgeOfChild { get; set; } 

        public int VaccieId { get; set; }   
        public Vaccine vaccine { get; set; }

        public int DoseId { get; set; }
        public Dose dose { get; set; }
        
    }
}
