using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public  class FollwUpVisit
    {
        public int Id { get; set; }
        public DateTime DateOfVisit { get; set; }
        public bool TypeOfFollwUp { get; set; }

        public int NCDCardId { get; set; }
        public NCDCard ncdCard { get; set; }
    }
}
