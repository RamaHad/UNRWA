using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class NCDCard
    {
        public int Id { get; set; }
        public DateTime DateOfCreated { get; set; }
        public int Diabetes { get; set; }
        public bool Pressure { get; set; }
        public string Sensitive { get; set; }

        public int IndividualId { get; set; }
        public Individual individual { get; set; }
    }
}
