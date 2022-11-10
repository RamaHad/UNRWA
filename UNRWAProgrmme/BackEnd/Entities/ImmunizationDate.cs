using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class ImmunizationDate
    {
        public int Id { set; get; }
        public DateTime DateOfImmunization { set; get; }

        public int ChildCardId { set; get; }    
        public ChildCard childCard { set; get; }

        public int ImmunizationProgrammeId { get; set; }
        public ImmunizationProgramme immunizationProgramme { set; get; }
    }
}
