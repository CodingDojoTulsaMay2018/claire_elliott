using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignments.Models;

namespace Assignments.Controllers
{
    public class ModelSurveyController : Controller
    {
        [HttpGet]
        [Route("model-survey")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("results")]
        [Route("model-survey/results")]
        public IActionResult Results(Surveyor submittedResults)
        {
            ViewBag.UsersName = submittedResults.UsersName;
            ViewBag.DojoLocation = submittedResults.DojoLocation;
            ViewBag.FavLanguage = submittedResults.FavLanguage;
            ViewBag.Comments = submittedResults.Comments;
            return View();
        }
    }
}