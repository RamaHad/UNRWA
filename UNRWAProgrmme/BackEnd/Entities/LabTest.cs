using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class LabTest
    {
        public int Id { get; set; } 
        public String Name { get; set; } 
        public int MinNormalResult { get; set; }
        public int MaxNormalResult { get; set; }

        public int LabTestTypeId { get; set; }
        public LabTestType labTestType { get; set; }

    }
}
