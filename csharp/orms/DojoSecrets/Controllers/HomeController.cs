using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSecrets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace DojoSecrets.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
 
        public HomeController(Context context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewModel loginReg = new ViewModel()
            {
                regUser = new User(),
                loginUser = new LoginUser()
            };

            if(HttpContext.Session.GetInt32("Id") != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View(loginReg);
            }
        }

        [HttpPost("Login")]
        [Route("")]
        public IActionResult Login(ViewModel FormData)
        {
            if(ModelState.IsValid)
            {
                LoginUser LoginUser = FormData.loginUser;
                var user = _context.Users.SingleOrDefault(u => u.Email == LoginUser.Email);
                if(user != null)
            {
               var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, LoginUser.Password))
                {
                    HttpContext.Session.SetInt32("Id", user.Id);
                     return RedirectToAction("Secrets");
                }
                
            }
            ModelState.AddModelError("loginUser.Password", "The email or password provided is incorrect.");
            return View("Index", FormData);
            }
            else
            {
                return View("Index", FormData);
            }
        }

        [HttpPost("Register")]
        [Route("")]
        public IActionResult Register(ViewModel FormData)
        {
            if (ModelState.IsValid)
            {
                User NewUser = FormData.regUser;
                User emailCheck = _context.Users.SingleOrDefault(u => u.Email == NewUser.Email);
                if(emailCheck == null)
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("Id", NewUser.Id);
                    return RedirectToAction("Secrets");
                }
                ModelState.AddModelError("users.Email", "Email is already registered.");
                return View("Index", FormData);
            }
            else
            {
                return View("Index", FormData);
            }
        }

        [HttpGet]
        [Route("Secrets")]
        public IActionResult Secrets()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
