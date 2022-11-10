using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class User :IdentityUser
    {
        public Employee employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
