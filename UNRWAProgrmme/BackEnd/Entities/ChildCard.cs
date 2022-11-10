using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class ChildCard
    {
        public int Id { get; set; } 
        public DateTime DateOfCreated { get; set; }
        public bool IsActive { get; set; }

        public int IndivisualId { get; set; }
        public Individual individual { get; set; }  
    }
}
