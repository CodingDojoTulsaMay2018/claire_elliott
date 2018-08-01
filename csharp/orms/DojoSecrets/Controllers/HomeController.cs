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
                loginUser = new LoginUser(),
            };

            if(HttpContext.Session.GetInt32("Id") != null)
            {
                return RedirectToAction("Secrets");
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
                    HttpContext.Session.SetString("FirstName", user.FirstName);
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
                    HttpContext.Session.SetString("FirstName", NewUser.FirstName);
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
            if(HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Index");
            }
            ViewModel secrets = new ViewModel()
            {
                secrets = _context.Secrets.OrderByDescending(s => s.CreatedAt).Take(5).ToList()
            };

            ViewBag.WelcomeName = HttpContext.Session.GetString("FirstName");
            ViewBag.CurrentUser = HttpContext.Session.GetInt32("Id");
            return View(secrets);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ViewModel FormData)
        {
            if(ModelState.IsValid)
            {
                Secret newSecret = FormData.secret;
                newSecret.Creator = _context.Users.SingleOrDefault(u => u.Id == (int)HttpContext.Session.GetInt32("Id"));
                newSecret.UserId = (int)HttpContext.Session.GetInt32("Id");
                _context.Secrets.Add(newSecret);
                _context.SaveChanges();

                TempData["Success"] = "Secret has been successfully added!";
                return RedirectToAction("Secrets");
            }
            else
            {
                ViewBag.WelcomeName = HttpContext.Session.GetString("FirstName");
                return View("Secrets", FormData);
            }
        }

        [HttpGet]
        [Route("Secrets/Popular")]
        public IActionResult PopularSecrets(){
            ViewModel secrets = new ViewModel()
            {
                secrets = _context.Secrets.OrderByDescending(s => s.Likes.Count)
                                            .Include(s => s.Likes)
                                            .ToList()
            };
            ViewBag.WelcomeName = HttpContext.Session.GetString("FirstName");
            ViewBag.CurrentUser = HttpContext.Session.GetInt32("Id");
            return View("PopularSecrets", secrets);
        }

        [HttpGet("Like/{id}")]
        public IActionResult Like(int id){
            Secret thisSecret = _context.Secrets.SingleOrDefault(s => s.Id == id);
            User thisUser = _context.Users.SingleOrDefault(u => u.Id == HttpContext.Session.GetInt32("Id"));

            Like newLike = new Like(){
                SecretId = id,
                Secret = _context.Secrets.SingleOrDefault(s => s.Id == id),
                UserId = (int)HttpContext.Session.GetInt32("Id"),
                User = _context.Users.SingleOrDefault(u => u.Id == HttpContext.Session.GetInt32("Id"))
            };
            _context.Likes.Add(newLike);
            _context.SaveChanges();
            thisSecret.Likes.Add(newLike);
            thisUser.Likes.Add(newLike);
            _context.SaveChanges();

            return RedirectToAction("PopularSecrets");
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id){
            Secret thisSecret = _context.Secrets.SingleOrDefault(s => s.Id == id);
            User thisUser = _context.Users.SingleOrDefault(u => u.Id == HttpContext.Session.GetInt32("Id"));

            _context.Secrets.Remove(thisSecret);
            thisUser.Secrets.Remove(thisSecret);
            _context.SaveChanges();

            return RedirectToAction("PopularSecrets");
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
