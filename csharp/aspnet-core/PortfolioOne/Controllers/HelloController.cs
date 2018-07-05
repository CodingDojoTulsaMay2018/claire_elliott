using Microsoft.AspNetCore.Mvc;
namespace PortfolioOne.Controllers
{
    public class HelloController : Controller
    {
        // INDEX
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "This is my Index!";
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