using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restauranter.Models;

namespace Restauranter.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult Create(Review review)
        {
            if(ModelState.IsValid)
            {
                DateTime current = DateTime.Now;
                Review NewReview = new Review
                {
                    ReviewerName = review.ReviewerName,
                    RestaurantName = review.RestaurantName,
                    Message = review.Message,
                    CreatedAt = current,
                    VisitDate = review.VisitDate,
                    Stars = review.Stars
                };
                _context.Add(NewReview);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            {
                
                return View("Index", review);
            }
        }

        public IActionResult Dashboard()
        {
            List<Review> allReviews = _context.review.OrderByDescending(r => r.CreatedAt).ToList();
            ViewBag.allReviews = allReviews;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
