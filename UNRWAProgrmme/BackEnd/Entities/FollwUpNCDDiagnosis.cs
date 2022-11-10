using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class FollwUpNCDDiagnosis
    {
        public int Id { get; set; }
        public DateTime DateOfVisit { get; set; }
        public bool Status { get; set; }

        public int NCDDiagnosisId { get; set; }
        public NCDDiagnosis ncdDiagnosis { get; set; }

    }
}
