using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class IndividualMeasurementResult
    {
        public int Id { get; set; }
        public float Result { get; set; }

        public int IndividualId { get; set; }
        public Individual individual{get; set;}

        public int MeasurementId { get; set; }
        public Measurement measurement { get; set; }
    }
}
