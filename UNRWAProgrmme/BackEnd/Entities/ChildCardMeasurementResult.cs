using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class ChildCardMeasurementResult
    {
        public int Id { get; set; }
        public float Result { get; set; }
        public DateTime DateOfMeasurement { get; set; }

        public int ChiledCardId { set; get; }
        public ChildCard childCard { get; set; }

        public int MeasurementId { get; set; }
        public Measurement measurement { get; set; }
    }
}
