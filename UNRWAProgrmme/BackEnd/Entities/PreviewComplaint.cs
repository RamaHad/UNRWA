using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public  class PreviewComplaint
    {
        public int Id { get; set; }

        public int PreviewId { get; set; }
        public Preview preview { get; set; }

        public int ComplaintId { get; set; }
        public Complaint complaint { get; set; }
    }
}
