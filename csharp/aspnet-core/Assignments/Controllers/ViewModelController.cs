using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Assignments.Models;

namespace Assignments.Controllers
{
    public class ViewModelController : Controller
    {
        [HttpGet]
        [Route("models")]
        public IActionResult Index()
        {
            Messages newMessage = new Messages() {
                MessageStr = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sem velit, tempor vitae mollis interdum, varius et arcu. Proin quis velit sed turpis aliquam ullamcorper euismod quis mi. Curabitur varius lacinia eros tristique condimentum. Aenean mollis, arcu eget porttitor varius, lectus libero sollicitudin erat, eu tincidunt tellus elit imperdiet nulla. Aenean ac fringilla dolor, eget vulputate urna. Aenean bibendum efficitur metus ac imperdiet. Aenean pretium ex at neque semper, id ultricies erat accumsan. Donec non orci at nisi cursus commodo id ac felis. Ut et urna nibh. Suspendisse felis ipsum, molestie at eros vitae, elementum tincidunt elit. Mauris sed erat in mi maximus pharetra. Donec pretium dui vitae molestie bibendum. Vivamus facilisis sapien et auctor pretium. Etiam sagittis gravida nibh sit amet auctor. Maecenas pretium, tellus ac dignissim imperdiet, nulla nisi ultricies sem, euismod varius ipsum enim vel neque. Sed ullamcorper quam nec posuere ullamcorper. Duis tempor eu dolor ac dapibus. Aliquam ut accumsan ligula. Ut turpis nisl, faucibus nec tincidunt ut, posuere eu neque. Quisque nec felis at ex aliquam semper nec euismod ligula."
            };
            return View(newMessage);
        }

        [HttpGet]
        [Route("models/numbers")]
        public IActionResult Numbers()
        {
            Numbers numberset = new Numbers() {
                NumbersArr = new List<int> {4,6,9,12,17,22,23,36,44,48}
            };
            return View(numberset);
        }

        [HttpGet]
        [Route("models/users")]
        public IActionResult Users()
        {
            User user = new User();
            return View(user);
        }

        [HttpGet]
        [Route("models/user")]
        public IActionResult SingleUser()
        {
            User user = new User();
            return View(user);
        }
    }
}