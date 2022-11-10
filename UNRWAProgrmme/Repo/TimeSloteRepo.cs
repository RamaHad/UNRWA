using BackEnd;
using BackEnd.Entities;
using Dto.TimeSlotesDto;
using IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class TimeSloteRepo :TimeSloteIRepo
    {
        ApplicationDBContext _context;

        public List<TimeSloteDto> GetAvaliableSlote(DateTime date, int providerId)
        {
            List<TimeSloteDto> avaliable = new List<TimeSloteDto>();
           _context = new ApplicationDBContext();
           var resrvations = _context.reservations.Where(t => (t.DateOfReservation.Date == date.Date)&& t.EmployeeForServiceId==providerId).ToList();
           var AllTimeSlote =_context.timeSlotes.ToList();
            bool val;
            for (int i = 0; i < AllTimeSlote.Count; i++)
            {

                val = true;
                for (int j = 0; j < resrvations.Count; j++)
                {
                    if ((resrvations[j].DateOfReservation.TimeOfDay == AllTimeSlote[i].Time.TimeOfDay))
                    {
                        val = false;
                        break;
                    }
                }
                if(val)
                {
                    avaliable.Add(new TimeSloteDto
                    {
                        Id = AllTimeSlote[i].Id,
                        Time = AllTimeSlote[i].Time.ToShortTimeString()

                });
                }
            }
            return avaliable;
        }

        public List<TimeSloteDto> GetTimeSlote()
        {
            _context = new ApplicationDBContext();
            var result = _context.timeSlotes
               .Select(t => new TimeSloteDto
               {
                   Id = t.Id,
                   Time = t.Time.ToShortTimeString()
               }).ToList();
            if(result!= null)
            {
                return result;
            }
  
  
            else return new List<TimeSloteDto> ();
        }
       

        public TimeSlote GetTimeSloteById(int id)
        {
            _context = new ApplicationDBContext();
            var result =_context.timeSlotes.Where(t => t.Id == id).FirstOrDefault();
            if (result != null) return result;
            else return new TimeSlote();
        }
    }
}
