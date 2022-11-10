using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class NCDDiagnosis
    {
        public int Id { get; set; }
        public DateTime DateOfDiagnosis { get; set; }

        public int NCDCardId { get; set; }
        public NCDCard ncdCard {get; set;}

        public int LateComplicationId { get; set; }
        public LateComplication lateComplication { get; set; }
    }
}
