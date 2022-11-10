using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class RequiredLabTest
    {
        public int Id { set; get; }
        public DateTime DateOfRequired { get; set; }

        public int ReservationId { set; get; }
        public Reservation reservation { set; get; }

        public int LabTestId { set; get; }
        public LabTest labTest { set; get; }
    }
}
