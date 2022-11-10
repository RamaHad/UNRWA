using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class Illness
    {
        public int Id { get; set; } 
        public string Name { get; set; }  
        
        public int IllnessTypeId { get; set; }
        public IllnessType illnessType{ get; set; }    
    }
}
