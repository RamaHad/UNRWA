using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class TreatmentPlan
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public int MedicineId { get; set; }
        public Medicine medicine { get; set; }

        public int PreviewId { get; set; }
        public Preview preview { get; set; }
    }
}
