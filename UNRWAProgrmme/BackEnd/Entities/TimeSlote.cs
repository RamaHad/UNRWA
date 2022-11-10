using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class TimeSlote
    {
        public int Id { set; get; }
        public DateTime Time { get; set; }
    }
}
