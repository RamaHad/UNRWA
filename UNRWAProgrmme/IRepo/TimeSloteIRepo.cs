using BackEnd.Entities;
using Dto.TimeSlotesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface TimeSloteIRepo
    {
        public List<TimeSloteDto> GetTimeSlote();
        public List<TimeSloteDto> GetAvaliableSlote(DateTime date , int providerId);
        public TimeSlote GetTimeSloteById(int id);
    }
}
