using BackEnd;
using BackEnd.Entities;
using Dto.UserDto;
using IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UNRWAHealthProgramme.Models;

namespace UNRWAHealthProgramme.Controllers
{

    public class UsersManager : Controller
    {
        private readonly UserIRepo _userRepo;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UsersManager(UserIRepo userRepo, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllUsers()
        {
      
            return View();
        }
        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _userRepo.Create(dto,_userManager);

                if (result.Succeeded)
                    return RedirectToAction(nameof(AllUsers));
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {

            //if (ModelState.IsValid)
            //{
            //    Microsoft.AspNetCore.Identity.SignInResult result = await _userRepo.Login(dto, _userManager, _signInManager);

            //    if (result.Succeeded)
            //    {
            //        var u = await _userManager.FindByEmailAsync(dto.Email);
            //        if (await _userManager.IsInRoleAsync(u, "Admin"))
            //        { return RedirectToAction("Index", "UsersManager"); }

            //        else if (await _userManager.IsInRoleAsync(u, "Doctor"))
            //        { return RedirectToAction("Index", "Doctor"); }

            //    }
            //    else
            //    {
            //        TempData["FaildLogin"] = "Invalid Email Or Password !";
            //        return RedirectToAction("Index", "Home", dto);
            //    }
            //    return RedirectToAction("Index", "Home", dto);

            //}
            //else
            //{
            //    TempData["FaildLogin"] = "Invalid Email Or Password !";
            //    return RedirectToAction("Index", "Home", dto);
            //}
            var u = CheckEmail(dto.Email);
            var result = false;

            if (u)
            {
                Microsoft.AspNetCore.Identity.SignInResult result1 = await _userRepo.Login(dto, _userManager, _signInManager);
                if (result1.Succeeded)
                {
                    result = true;
                    return Ok(result);

                }
                else
                {
                    result = false;
                    return Ok(result);
                }
            }
            else
            {
                result = false;
                return Ok(result);
            }

        }
        public async Task<IActionResult> Logout()
        {
            _userRepo.Logout(_signInManager);
            return RedirectToAction("Index", "Home");

                }

        public bool CheckEmail(string email)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public async Task<IActionResult> RedirectTheUser(LoginDto dto)
        {
            var u = await _userManager.FindByEmailAsync(dto.Email);
            if (await _userManager.IsInRoleAsync(u, "Admin"))
            {
                //return RedirectToAction("Index", "UsersManager");
                return Json(new { redirectUrl = Url.Action("Index", "UsersManager") });
            }

            else if (await _userManager.IsInRoleAsync(u, "Doctor"))
            {
                //  return RedirectToAction("Index", "Doctor"); 
                return Json(new { redirectUrl = Url.Action("Index", "Doctor") });
            }
            else
            {
                return NotFound();
            }
        }
    }

}
