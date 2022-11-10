using BackEnd.Entities;
using Dto.UserDto;
using Microsoft.AspNetCore.Identity;

namespace IRepo
{
    public interface UserIRepo
    {
        public Task<IdentityResult> Create(CreateUserDto dto, UserManager<User> _userManager);
        public Task<SignInResult> Login(LoginDto dto, UserManager<User> _userManager , SignInManager<User> _signInManager);
        public void Logout(SignInManager<User> _signInManager);
        public  UserDto FindUserName( string id);
    }
}