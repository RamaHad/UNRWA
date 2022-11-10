using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class NCDMedicine
    {
        public int Id { get; set; }
        public DateTime DateOfPrescription { get; set; }
        public bool Status { get; set; } 
        public int amount { get; set; }

        public int MedicineId { get; set; }
        public Medicine medicine { get; set; }

        public int NCDCardId { get; set; }
        public NCDCard ncdCard { get; set; }
    }
}
