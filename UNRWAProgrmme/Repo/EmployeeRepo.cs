using BackEnd;
using Dto.EmployeesDto;
using IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class EmployeeRepo : EmployeeIRepo
    {
        private  ApplicationDBContext _context;
        public  List<EmployeeDto> GetEmployeesByTeamId(int teamId)
        {
            _context = new ApplicationDBContext();
            var result =   _context.employees
                                   .Include(i => i.individual)
                                   .Where(t => t.TeamId == teamId)
                                   .Select(e => new EmployeeDto
                                   {
                                       Id = e.Id,
                                       Name = e.individual.FirstName + " " + e.individual.LastName
                                   }).ToList();
            if(result!= null) return result;
            else return new List<EmployeeDto>();
        }
        public EmployeeDto FindEmployeeByUserId(string UserId)
        {
            ApplicationDBContext context = new ApplicationDBContext();
            var employee = context.Users
                .Include(e => e.employee).Where(i => i.Id.Equals(UserId))
                .Include(i => i.employee.individual)
                .Select(d => new EmployeeDto
                {
                    Id = d.EmployeeId,
                    Name = d.employee.individual.FirstName + " " + d.employee.individual.LastName

                })
                .First();
            return employee;
        }

    }
}
