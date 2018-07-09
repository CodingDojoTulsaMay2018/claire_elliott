using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioOne.Controllers
{
    public class HelloController : Controller
    {
        // INDEX
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        // PROJECTS
        [HttpGet]
        [Route("projects")]
        public string Projects()
        {
            return "These are my projects!";
        }
        // CONTACT INFORMATION
        [HttpGet]
        [Route("contact")]
        public string Contact()
        {
            return "This is my Contact!";
        }
    }   
}