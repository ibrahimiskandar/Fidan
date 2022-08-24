using LimakAz.Areas.Manage.ViewModels;
using LimakAz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        //public async Task<IActionResult> Index()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        UserName = "SuperAdmin",
        //        FullName = "Fidan Mammadova"
        //    };

        //    await _userManager.CreateAsync(admin, "Admin123");

        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    await _roleManager.CreateAsync(role1);
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    await _roleManager.CreateAsync(role2);
        //    IdentityRole role3 = new IdentityRole("Member");
        //    await _roleManager.CreateAsync(role3);

        //    AppUser appUser = await _userManager.FindByNameAsync("SuperAdmin");

        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");


        //    return View();
        //}

        /*        public async Task<IActionResult> CreateRole()
                {
                    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));

                    return View();
                }
        */

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        FullName = "Super Admin",
        //        UserName = "SuperAdmin",
        //        Email = "superadmin@gmail.com",
        //        IsAdmin = true,
        //    };

        //    var result = await _userManager.CreateAsync(admin, "Admin123");

        //    if (!result.Succeeded)
        //        return Ok(result.Errors);

        //    var roleResult = await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

        //    if (!roleResult.Succeeded)
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError("Name", item.Description);
        //        }
        //    }

        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");

        //    return View();
        //}
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser admin = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == loginVM.UserName.ToUpper() && x.IsAdmin);

            if (admin == null)
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(admin, loginVM.Password, loginVM.IsPersistent, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır");
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
