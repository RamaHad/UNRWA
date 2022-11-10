using BackEnd;
using BackEnd.Entities;
using Dto.UserDto;
using IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Repo
{
    public class UserRepo : UserIRepo
    {


        public async Task<IdentityResult> Create(CreateUserDto dto, UserManager<User> _userManager)
        {

            User user = new User()
            {
                Email = dto.Email,
                EmployeeId = dto.employeeId,
                UserName = dto.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
            return result;
        }

        public UserDto FindUserName(string id)
        {
            ApplicationDBContext context = new ApplicationDBContext();
            var user = context.Users
                .Include(e => e.employee).Where(i => i.Id.Equals(id))
                .Include(i => i.employee.individual)
                .Select(d => new UserDto
                {
                    FirstName = d.employee.individual.FirstName,
                    LastName = d.employee.individual.LastName,
                    EmployeeIdId = d.EmployeeId
                })
                .First();
            
            return user;
        }
        public async Task<SignInResult> Login(LoginDto dto, UserManager<User> _userManager, SignInManager<User> _signInManager)
        {

            await _signInManager.SignOutAsync();
            SignInResult result = await _signInManager.PasswordSignInAsync(await _userManager.FindByEmailAsync(dto.Email), dto.Password, false, false);
            return result;
        }

        public async void Logout(SignInManager<User> _signInManager)
        {
            await _signInManager.SignOutAsync();

        }
    }
}