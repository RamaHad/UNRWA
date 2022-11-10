using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MedicineTypeId { get; set; }
        public MedicineType medicineType { get; set; }  
    }
}
