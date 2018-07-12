using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        private LoginRegistrationContext _context;
 
        public HomeController(LoginRegistrationContext context)
        {
            _context = context;
        }
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Process(Users logUser)
        {
            var user = _context.users.SingleOrDefault(u => u.Email == logUser.Email);
            if(user != null && logUser.Password != null)
            {
               var Hasher = new PasswordHasher<Users>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, logUser.Password))
                {
                     return RedirectToAction("Success");
                }
                
            }
            ModelState.AddModelError("Password", "The email or password provided is incorrect.");
            return View("Login", logUser);
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Create(Users user)
        {
            if (ModelState.IsValid)
            {
                var emailCheck = _context.users.SingleOrDefault(u => u.Email == user.Email);
                if(emailCheck == null)
                {
                    PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    _context.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("Success");
                }
                ModelState.AddModelError("Email", "Email is already registered.");
                return View("Register",user);
            }
            else
            {
                return View("Register", user);
            }
        }

        [Route("Success")]
        public IActionResult Success()
        {
            TempData["Message"] = "You were successful";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}