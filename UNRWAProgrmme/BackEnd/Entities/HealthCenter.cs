using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class HealthCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AreaId { get; set; }
        public Area area { get; set; }
    }
}
