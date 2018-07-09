using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignments.Models;

namespace Assignments.Controllers
{
    public class SurveyValidateController : Controller
    {
        [HttpGet]
        [Route("survey")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("survey")]
        [Route("survey")]
        public IActionResult Process(Surveyor surveyor)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Results","SurveyValidate");
            }
            else
            {
                return View("Index", surveyor);
            }
            
        }

        [HttpGet]
        [Route("survey/results")]
        public IActionResult Results()
        {
            return View("Results");
        }
    }
}