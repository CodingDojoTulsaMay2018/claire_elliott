using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignments.Models;

namespace Assignments.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        [Route("form-submission")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("process")]
        [Route("form-submission")]
        public IActionResult Process(Form form)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Results","Form");
            }
            else
            {
                return View("Index");
            }
            
        }

        [HttpGet]
        [Route("form-submission/results")]
        public IActionResult Results()
        {
            return View("Results");
        }
    }
}