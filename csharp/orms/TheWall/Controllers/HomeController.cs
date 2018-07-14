using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        private WallContext _context;
 
        public HomeController(WallContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Process(Users logUser)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == logUser.Email);
            if(user != null && logUser.Password != null)
            {
               var Hasher = new PasswordHasher<Users>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, logUser.Password))
                {
                    HttpContext.Session.SetInt32("Id", user.UserId);
                    HttpContext.Session.SetString("UserName", user.FirstName);
                     return RedirectToAction("Dashboard");
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
                var emailCheck = _context.Users.SingleOrDefault(u => u.Email == user.Email);
                if(emailCheck == null)
                {
                    PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    _context.Add(user);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("Id", user.UserId);
                    HttpContext.Session.SetString("UserName", user.FirstName);
                    return RedirectToAction("Dashboard");
                }
                ModelState.AddModelError("Email", "Email is already registered.");
                return View("Register",user);
            }
            else
            {
                return View("Register", user);
            }
        }

        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login");
            }
            PostsComments view = new PostsComments()
            {
                users = new Users(),
                comments = new Comments(),
                posts = new Posts(),
            };
            
            List<Posts> allPosts = _context.Posts.Include(p => p.Creator).Include(p => p.Comments).ToList();
            ViewBag.allPosts = allPosts.OrderByDescending(p => p.CreatedAt).ToList();
            ViewBag.WelcomeName = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult Posting(Posts post){
            Users poster = _context.Users.SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("Id"));
            Posts newPost = new Posts {
                Creator = poster,
                Content = post.Content,
                UserId = (int)HttpContext.Session.GetInt32("Id")
            };
            _context.Posts.Add(newPost);
            _context.SaveChanges();
            poster.Posts.Add(newPost);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public IActionResult Commenting(Comments comment){
            Users commenter = _context.Users.SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("Id"));
            Posts post = _context.Posts.SingleOrDefault(p => p.PostId == Convert.ToInt32(Request.Form["MessageId"]));

            
            Comments newComment = new Comments {
                Commenter = commenter,
                Content = comment.Content,
                UserId = (int)HttpContext.Session.GetInt32("Id"),
                PostId = Convert.ToInt32(Request.Form["MessageId"])
            };
            _context.Comments.Add(newComment);
            _context.SaveChanges();
            post.Comments.Add(newComment);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("Logout")]
        [Route("")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
