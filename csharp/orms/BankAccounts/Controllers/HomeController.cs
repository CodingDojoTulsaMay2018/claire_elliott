using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        List<Transaction> usersTransactions { get; set; }
        private BankContext _context;
 
        public HomeController(BankContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Process(User logUser)
        {
            var user = _context.user.SingleOrDefault(u => u.Email == logUser.Email);
            if(user != null && logUser.Password != null)
            {
               var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, logUser.Password))
                {
                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetString("UserName", user.FirstName);
                    return RedirectToAction("Account", new{id=user.Id});
                }
            }
            ModelState.AddModelError("Password", "The email or password provided is incorrect.");
            return View("Index", logUser);
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var emailCheck = _context.user.SingleOrDefault(u => u.Email == user.Email);
                if(emailCheck == null)
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    _context.user.Add(user);
                    _context.SaveChanges();

                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetString("UserName", user.FirstName);
                    return RedirectToAction("Account", new{id=user.Id});
                }
                ModelState.AddModelError("Email", "Email is already registered.");
                return View("Register", user);
            }
            else
            {
                return View("Register", new{id=user.Id});
            }
        }

        [HttpGet("Account/{id}")]
        public IActionResult Account(int id)
        {
            if(HttpContext.Session.GetInt32("Id") == null){
                return RedirectToAction("Index");
            }
            else
            {
                usersTransactions = _context.transaction.Where(t => t.user_Id == HttpContext.Session.GetInt32("Id")).ToList();
                ViewBag.Transactions = usersTransactions.OrderByDescending(t => t.CreatedAt);
                ViewBag.Balance = usersTransactions.Sum(t => Convert.ToDouble(t.Amount));
                ViewBag.WelcomeName = HttpContext.Session.GetString("UserName");
                return View();
            }
        }

        [HttpPost]
        [Route("Account/{id}")]
        public IActionResult Transact(Transaction transaction)
        {
            usersTransactions = _context.transaction.Where(t => t.user_Id == HttpContext.Session.GetInt32("Id")).ToList();
            if(usersTransactions.Sum(t => Convert.ToDouble(t.Amount)) + transaction.Amount < 0){
                ModelState.AddModelError("Amount", "Insufficient funds.");
                ViewBag.Transactions = usersTransactions.OrderByDescending(t => t.CreatedAt);
                ViewBag.Balance = usersTransactions.Sum(t => Convert.ToDouble(t.Amount));
                ViewBag.WelcomeName = HttpContext.Session.GetString("UserName");
                return View("Account", transaction);
            }
            else{
                DateTime current = DateTime.Now;
                Transaction newTransaction = new Transaction {
                Amount = transaction.Amount,
                CreatedAt = current,
                user_Id = (int)HttpContext.Session.GetInt32("Id")
                };
                _context.transaction.Add(newTransaction);
                _context.SaveChanges();

                return RedirectToAction("Account", new{id = HttpContext.Session.GetInt32("Id")});
            }
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}