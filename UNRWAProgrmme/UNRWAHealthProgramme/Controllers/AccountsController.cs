using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UNRWAHealthProgramme.Models;

namespace UNRWAHealthProgramme.Controllers
{
    public class AccountsController : Controller
    {
        //private UserManager<ApplicationUser> _userManager;
        //private SignInManager<ApplicationUser> _signInManager;

        //public AccountsController(UserManager<ApplicationUser> userMgr, SignInManager<ApplicationUser> signinMgr)
        //{
        //    _userManager = userMgr;
        //    _signInManager = signinMgr;
        //}

        //[AllowAnonymous]
        //public IActionResult Login(string returnUrl)
        //{
        //    LoginModel login = new LoginModel();
        //    login.ReturnUrl = returnUrl;
        //    return View(login);
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginModel login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser appUser = await _userManager.FindByEmailAsync(login.Email);
        //        if (appUser != null)
        //        {
        //            await _signInManager.SignOutAsync();
        //            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
        //            if (result.Succeeded)
        //                return Redirect(login.ReturnUrl ?? "/");
        //        }
        //        ModelState.AddModelError(nameof(login.Email), "Login Failed: Invalid Email or password");
        //    }
        //    return View(login);
        //}
        
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
