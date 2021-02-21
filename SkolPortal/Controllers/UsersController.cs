using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkolPortal.Data;
using SkolPortal.Models;

namespace SkolPortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

  
            

        public async Task<IActionResult> Index()
        {
            ViewBag.Admins = await _userManager.GetUsersInRoleAsync("Admin");
            ViewBag.Teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            ViewBag.Students = await _userManager.GetUsersInRoleAsync("Student");

            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Roles = _roleManager.Roles;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await _userManager.CreateAsync(user, "BytMig123!");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("Index", "Users");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

                return View();

            }
        }
    }
