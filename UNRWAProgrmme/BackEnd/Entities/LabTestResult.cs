using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class LabTestResult
    {
        public int Id { get; set; }
        public  int Result { get; set; }
        public DateTime DateOfLabTest { get; set; }

        public int IndividualId { set; get; }
        public Individual individual { get; set; }

        public int LabTestId { get; set; }
        public LabTest labTest { get; set; }
    }
}
