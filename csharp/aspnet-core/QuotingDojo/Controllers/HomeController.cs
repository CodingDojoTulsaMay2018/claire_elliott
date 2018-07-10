using System;
using System.Web;
using DbConnection;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult Create(Quote newquote)
        {
            if(ModelState.IsValid)
            {
                DateTime current = DateTime.Now;
                string date = current.ToString("yyyy-MM-dd HH:mm:ss");
                DbConnector.Execute($"INSERT INTO quote (message,author,created_at) VALUES ('{newquote.Message}','{newquote.Author}','{date}')");
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index", newquote);
            }
            
        }

        public IActionResult Dashboard()
        {
            List<Dictionary<string,object>> AllQuotes = DbConnector.Query("SELECT * FROM quote ORDER BY created_at DESC");
            ViewBag.AllQuotes = AllQuotes;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
