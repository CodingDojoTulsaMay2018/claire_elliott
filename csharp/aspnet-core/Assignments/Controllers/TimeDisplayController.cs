using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignments.Controllers
{
    public class TimeDisplayController : Controller
    {
        [HttpGet]
        [Route("time-display")]
        public IActionResult Index()
        {
            return View();
        }
    }
}