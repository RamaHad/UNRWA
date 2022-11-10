using Dto.EmployeesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface EmployeeIRepo
    {
        public List<EmployeeDto> GetEmployeesByTeamId(int teamId);
        public EmployeeDto FindEmployeeByUserId(string UserId);
    }
}
