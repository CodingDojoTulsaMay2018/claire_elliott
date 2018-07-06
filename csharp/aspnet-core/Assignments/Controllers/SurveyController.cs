using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignments.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("survey")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("survey/results")]
        public IActionResult Results(string UsersName, string DojoLocation, string FavLanguage, string Comments)
        {
            ViewBag.UsersName = UsersName;
            ViewBag.DojoLocation = DojoLocation;
            ViewBag.FavLanguage = FavLanguage;
            ViewBag.Comments = Comments;
            return View();
        }
    }
}