using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.UserDto
{
    public class CreateUserDto
    {
        [ Required]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int employeeId { get; set; }
    }
}
