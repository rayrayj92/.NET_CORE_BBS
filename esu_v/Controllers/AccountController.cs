using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using esu_v.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace esu_v.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AdminUser> _userManager;
        private readonly SignInManager<AdminUser> _signInManager;
        private IPasswordHasher<AdminUser> _passwordHasher;

        public AccountController(UserManager<AdminUser> userManager, SignInManager<AdminUser> signInManager, IPasswordHasher<AdminUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                AdminUser au = new AdminUser
                {
                    UserName = user.UserName,
                    Email = user.Email
                };

                IdentityResult result = await _userManager.CreateAsync(au, user.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Admin");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                
            }
            return View(user);
        }
        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Admin(Login login)
        {
            if (ModelState.IsValid)
            {
                AdminUser adminUser = await _userManager.FindByEmailAsync(login.Email);
                if (adminUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(adminUser, login.Password, false, false);

                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login failed, wrong credentials.");
                }

            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


    }
}