using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RockPaperScissors.Models;

namespace RockPaperScissors.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("ties") == null)
            {
                HttpContext.Session.SetInt32("ties",0);
                HttpContext.Session.SetInt32("wins",0);
                HttpContext.Session.SetInt32("losses",0);
            }
            TempData["ties"] = HttpContext.Session.GetInt32("ties");
            TempData["losses"] = HttpContext.Session.GetInt32("losses");
            TempData["wins"] = HttpContext.Session.GetInt32("wins");
            return View();
        }

        [HttpGet("Rock")]
        public IActionResult Rock()
        {
            Random rand = new Random();
            int num = rand.Next(1,4);
            if(num == 1)
            {
                TempData["message"] = "The computer picked rock, and you picked rock.\nYou tie!";
                HttpContext.Session.SetInt32("ties",(int)(HttpContext.Session.GetInt32("ties")+1));
            }
            else if(num == 2)
            {
                TempData["message"] = "The computer picked paper, and you picked rock.\nYou lose!!";
                HttpContext.Session.SetInt32("losses",(int)(HttpContext.Session.GetInt32("losses")+1));
            }
            else
            {
                TempData["message"] = "The computer picked scissors, and you picked rock.\nYou win!";
                HttpContext.Session.SetInt32("wins",(int)(HttpContext.Session.GetInt32("wins")+1));
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Paper")]
        public IActionResult Paper()
        {
            Random rand = new Random();
            int num = rand.Next(1,4);
            if(num == 1)
            {
                TempData["message"] = "The computer picked rock, and you picked paper.\nYou win!";
                HttpContext.Session.SetInt32("wins",(int)(HttpContext.Session.GetInt32("wins")+1));
            }
            else if(num == 2)
            {
                TempData["message"] = "The computer picked paper, and you picked paper.\nYou tie!";
                HttpContext.Session.SetInt32("ties",(int)(HttpContext.Session.GetInt32("ties")+1));
            }
            else
            {
                TempData["message"] = "The computer picked scissors, and you picked paper.\nYou lose!!";
                HttpContext.Session.SetInt32("losses",(int)(HttpContext.Session.GetInt32("losses")+1));
            }
            return RedirectToAction("Index");
        }

        [HttpGet("Scissors")]
        public IActionResult Scissors()
        {
            Random rand = new Random();
            int num = rand.Next(1,4);
            if(num == 1)
            {
                TempData["message"] = "The computer picked rock, and you picked scissors.\nYou lose!!";
                HttpContext.Session.SetInt32("losses",(int)(HttpContext.Session.GetInt32("losses")+1));
            }
            else if(num == 2)
            {
                TempData["message"] = "The computer picked paper, and you picked scissors.\nYou win!";
                HttpContext.Session.SetInt32("wins",(int)(HttpContext.Session.GetInt32("wins")+1));
            }
            else
            {
                TempData["message"] = "The computer picked scissors, and you picked scissors.\nYou tie!";
                HttpContext.Session.SetInt32("ties",(int)(HttpContext.Session.GetInt32("ties")+1));
            }

            return RedirectToAction("Index");
        }
    }
}
