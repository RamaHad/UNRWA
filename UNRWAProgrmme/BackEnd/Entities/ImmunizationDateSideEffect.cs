using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class ImmunizationDateSideEffect
    {
        public int Id { set; get; }

        public int ImmunizationDateId { set; get; }
        public ImmunizationDate immunizationDate { set; get; }  

        public int SideEffectId { set; get; }
        public SideEffect sideEffect { set; get; }
    }
}
