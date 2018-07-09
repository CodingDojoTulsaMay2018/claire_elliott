using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignments.Models;
using System;
using System.Text;

namespace Assignments.Controllers
{
    public class RandomController : Controller
    {
        [HttpGet]
        [Route("random")]
        public IActionResult Index()
        {
            int counter = HttpContext.Session.GetInt32("counter") ?? default(int);
            counter+= 1;
            HttpContext.Session.SetInt32("counter", counter);
            ViewBag.Counter = counter;
            return View("Index");
            
        }

        [HttpGet]
        [Route("random/generate")]
        public IActionResult Generate()
        {
            string alphanum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for(int i = 0; i < 14; i++)
            {
                sb.Append(alphanum[rand.Next(0,36)]);
            }
            TempData["passcode"] = sb.ToString();
            return RedirectToAction("Index", TempData["passcode"]);
        }
    }
}