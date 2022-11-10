using Dto.ApoointmentsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ViewDto
{
    public class QueueDto
    {
        public int employeeId { get; set; }
        public List<AppointmentDto> AppointmentsInQueue { get; set; } = new List<AppointmentDto>();
    }
}
