using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class ResidentialAddress
    {
        public int Id { get; set; } 
        public string Address { get; set; }  
        
        public int AreaId { get; set; } 
        public Area area { get; set; }  
    }
}
