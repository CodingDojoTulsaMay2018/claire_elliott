using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi") == null){
                HttpContext.Session.SetObjectAsJson("Dojodachi", new Dojodachi("Sprinkles"));
                Dojodachi NewDojo = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");

                return View(NewDojo);
            }
            else
            {
                Dojodachi NewDojo = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
                return View(NewDojo);
            }
        }

        public JsonResult Feed()
        {
            Dojodachi NewDojo = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            NewDojo.Feed();
            HttpContext.Session.SetObjectAsJson("Dojodachi", NewDojo);
            return Json(NewDojo);
        }

        public IActionResult Play()
        {
            Dojodachi NewDojo = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            NewDojo.Play();
            HttpContext.Session.SetObjectAsJson("Dojodachi", NewDojo);
            return Json(NewDojo);
        }

        public IActionResult Work()
        {
            Dojodachi NewDojo = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            NewDojo.Work();
            HttpContext.Session.SetObjectAsJson("Dojodachi", NewDojo);
            return Json(NewDojo);
        }

        public IActionResult Sleep()
        {
            Dojodachi NewDojo = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            NewDojo.Sleep();
            HttpContext.Session.SetObjectAsJson("Dojodachi", NewDojo);
            return Json(NewDojo);
        }

        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
