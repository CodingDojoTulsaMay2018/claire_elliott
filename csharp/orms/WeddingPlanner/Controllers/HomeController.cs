using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers
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
                regUser = new Users(),
                loginUser = new LoginCheck()
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
                LoginCheck LoginUser = FormData.loginUser;
                var user = _context.Users.SingleOrDefault(u => u.Email == LoginUser.Email);
                if(user != null)
            {
               var Hasher = new PasswordHasher<Users>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, LoginUser.Password))
                {
                    HttpContext.Session.SetInt32("Id", user.Id);
                     return RedirectToAction("Dashboard");
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
                Users NewUser = FormData.regUser;
                Users emailCheck = _context.Users.SingleOrDefault(u => u.Email == NewUser.Email);
                if(emailCheck == null)
                {
                    PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                    NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("Id", NewUser.Id);
                    return RedirectToAction("Dashboard");
                }
                ModelState.AddModelError("users.Email", "Email is already registered.");
                return View("Index", FormData);
            }
            else
            {
                return View("Index", FormData);
            }
        }

        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelViewDashboard view = new ModelViewDashboard()
                {
                    users = new Users(),
                    weddings = new Weddings(),
                    hasGuests = new HasGuests()
                };

                List<Weddings> allWeddings = _context.Weddings.ToList();
                ViewBag.Weddings = allWeddings;
                return View();
            }
            
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
