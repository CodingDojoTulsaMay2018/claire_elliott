using Microsoft.AspNetCore.Mvc;

namespace PortfolioTwo.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult index()
        {
            return View();
        }

        [HttpGet]
        [Route("contact")]
        public IActionResult contact()
        {
            return View();
        }

        [HttpGet]
        [Route("projects")]
        public IActionResult projects()
        {
            return View();
        }
    }
}