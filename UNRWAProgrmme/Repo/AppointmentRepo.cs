using BackEnd;
using BackEnd.Entities;
using Dto.ApoointmentsDto;
using Dto.AppointmentsDto;
using IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class AppointmentRepo : AppointmentIRepo
    {
        private  ApplicationDBContext _context;

        public bool AddQuickAppointment(AddQuickAppointmentDto addQuickAppointmentDto)
        {
            try
            {
                _context = new ApplicationDBContext();
                Reservation reservation = new Reservation();
                reservation.DateOfReservation = addQuickAppointmentDto.DateOfReservation;
                reservation.ClerickId = addQuickAppointmentDto.ClerckId;
                reservation.EmployeeForServiceId = addQuickAppointmentDto.EmployeeForServiceId;
                reservation.ServiceId = addQuickAppointmentDto.ServiceId;
                reservation.IndevisualId = addQuickAppointmentDto.IndividualId;
                reservation.Status = addQuickAppointmentDto.Status;
                _context.Add(reservation);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAppointment(int AppointmentlId)
        {
            _context = new ApplicationDBContext();
            var appointment = _context.reservations.FirstOrDefault(x => x.Id == AppointmentlId);
            if(appointment != null)
            {
                var result = _context.reservations.Remove(appointment);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<AppointmentDto> GetIndividualAppointments(int individualId)
        {
            _context = new ApplicationDBContext();
            
            //check if individual is exesit
            var individual = _context.Individual.FirstOrDefault(x => x.Id == individualId);

            //select info from reservation
            if (individual != null)
            {
               var result = _context.reservations
                    .OrderByDescending(x => x.DateOfReservation)
                             .Where(i => i.IndevisualId == individualId)
                             .Include(c => c.clerick)
                             .Include(e => e.employeeForService)
                             .Include(s => s.service)
                             .Include(i => i.individual)
                             .Select(a => new AppointmentDto
                             {
                                 AppointmentId = a.Id,
                                 IndividualId = a.IndevisualId,
                                 DateOfReservation = a.DateOfReservation,
                                 Status = a.Status,
                                 ClerckName = a.clerick.individual.FirstName + " " + a.clerick.individual.LastName,
                                 EmployeeForServiceName = a.employeeForService.individual.FirstName + " " + a.employeeForService.individual.LastName,
                                 ServiceName = a.service.Name,
                                 IndividualName = a.individual.FirstName + " " + a.individual.LastName
                                 
                             })
                             .ToList();
                if (result != null) return result;
                else return new List<AppointmentDto>();
            }
            else  //if individual is not exesit return null
            {
                return null;
            }
        }
        public bool AddAppointment(AddAppointmentDto addAppointmentDto)
        {

            try
            {
                _context = new ApplicationDBContext();
                TimeSloteRepo _timeSloteRepo = new TimeSloteRepo();
                var time = _timeSloteRepo.GetTimeSloteById(addAppointmentDto.TimeSloteId);
                TimeSpan s = new TimeSpan(time.Time.Hour, time.Time.Minute, time.Time.Second);
                addAppointmentDto.DateOfReservation = addAppointmentDto.DateOfReservation.Date + s;

                Reservation reservation = new Reservation();
                reservation.ClerickId = addAppointmentDto.ClerckId;
                reservation.ServiceId = addAppointmentDto.ServiceId;
                reservation.EmployeeForServiceId = addAppointmentDto.EmployeeForServiceId;
                reservation.IndevisualId = addAppointmentDto.IndividualId;
                reservation.DateOfReservation = addAppointmentDto.DateOfReservation;
                reservation.Status = 3;
                _context.Add(reservation);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
            

        }

        public bool EditAppointment(EditAppointmentDto editAppointmentDto)
        {
            try
            {
                _context = new ApplicationDBContext();
                var reservation = _context.reservations.FirstOrDefault(r => r.Id == editAppointmentDto.EditAppointmentId);
                if (reservation != null)
                {
                    TimeSloteRepo _timeSloteRepo = new TimeSloteRepo();
                    var time = _timeSloteRepo.GetTimeSloteById(editAppointmentDto.NewTimeSlotId);
                    TimeSpan s = new TimeSpan(time.Time.Hour, time.Time.Minute, time.Time.Second);
                    editAppointmentDto.NewDate = editAppointmentDto.NewDate.Date + s;

                    reservation.ServiceId = editAppointmentDto.NewServiceId;
                    reservation.EmployeeForServiceId = editAppointmentDto.NewEmployeeForServiceId;
                    reservation.IndevisualId = editAppointmentDto.EditAppointmentIndividualId;
                    reservation.DateOfReservation = editAppointmentDto.NewDate;

                    _context.Update(reservation);
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public AppointmentDto GetNextAppointment(ApplicationDBContext _context, string userId,EmployeeIRepo employeeIRepo)
        {
            try
            {
                this._context = _context;
                var time = DateTime.Now;
                var employee = employeeIRepo.FindEmployeeByUserId(userId);
                var nextReservation = _context.reservations
                    .OrderBy(d => d.DateOfReservation)
                    .Where(
                     e => e.EmployeeForServiceId == employee.Id &&  (
                     e.DateOfReservation.Date == time.Date && 
                     e.Status ==3 &&
                     e.DateOfReservation.TimeOfDay >= time.TimeOfDay) 
                     ||
                     (
                     e.DateOfReservation.Date == time.Date &&
                     e.Status == 2 &&
                     e.DateOfReservation.TimeOfDay >= time.TimeOfDay)
                     )
                    
                    .Select(r => new AppointmentDto
                    {
                        AppointmentId = r.Id,
                        IndividualId = r.IndevisualId,
                        DateOfReservation = r.DateOfReservation,
                        Status = r.Status,
                        ServiceName = r.service.Name,
                        IndividualName = r.individual.FirstName + " " + r.individual.LastName,
                        EmployeeForServiceId= employee.Id,
                    })
                    .FirstOrDefault();

                if (nextReservation != null) return nextReservation;
                else return new AppointmentDto();
            }
            catch
            {
                throw;
            }
        }
        public List<AppointmentDto> GetEmployeeQueue(ApplicationDBContext _context, int employeeId)
        {
            try
            {
                var queue = _context.reservations.OrderBy(d => d.DateOfReservation)
               .Where(r => 
               r.EmployeeForServiceId == employeeId &&
              ( ( r.DateOfReservation.Date == DateTime.Now.Date &&
                 r.DateOfReservation.TimeOfDay >= DateTime.Now.TimeOfDay &&
                 r.Status == 3 /*waiting*/) 
                ||
                (r.EmployeeForServiceId == employeeId &&
                 r.DateOfReservation.Date == DateTime.Now.Date && 
                 r.DateOfReservation.TimeOfDay >= DateTime.Now.TimeOfDay &&

                 r.Status == 2 /*quick*/))
               )
              
               .Select(r => new AppointmentDto
               {
                   AppointmentId = r.Id,
                   IndividualId = r.IndevisualId,
                   DateOfReservation = r.DateOfReservation,
                   Status = r.Status,
                   ServiceName = r.service.Name,
                   IndividualName = r.individual.FirstName + " " + r.individual.LastName,
                   EmployeeForServiceId = r.EmployeeForServiceId
               }).ToList();
                if (queue != null) return queue;
                else return new List<AppointmentDto>();
            }
            catch
            {
                throw;
            }

        }


    }
}


// 0 missing
// 1 done
// 2 quick
// 3 waiting