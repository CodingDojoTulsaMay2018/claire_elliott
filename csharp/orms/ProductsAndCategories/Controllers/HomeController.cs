using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
 
        public HomeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Products/New")]
        public IActionResult NewProduct()
        {
            ViewModel product = new ViewModel(){
                Product = new Products()
            };
            return View(product);
        }

        [HttpGet]
        [Route("Categories/New")]
        public IActionResult NewCategory()
        {
            ViewModel categories = new ViewModel(){
                Category = new Categories()
            };
            return View(categories);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ViewModel FormData)
        {
            if(FormData.Product != null)
            {
                if(ModelState.IsValid){
                    Products newProduct = FormData.Product;
                    _context.Products.Add(newProduct);
                    _context.SaveChanges();

                    TempData["Success"] = "Product has been successfully added!";
                    return RedirectToAction("NewProduct");
                }
                else
                {
                    return View("NewProduct", FormData);
                }
            }
            if(FormData.Category != null)
            {
                if(ModelState.IsValid){
                    Categories newCategory = FormData.Category;
                    _context.Categories.Add(newCategory);
                    _context.SaveChanges();

                    TempData["Success"] = "Category has been successfully added!";
                    return RedirectToAction("NewCategory");
                }
                else
                {
                    return View("NewCategory", FormData);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("Categories/{id}")]
        public IActionResult CategoryProfile(int id)
        {
            ViewModel view = new ViewModel(){
                Category = _context.Categories.SingleOrDefault(c => c.Id == id),
                Product = new Products(),
                Groupings = new Groupings(),
                CategoryList = _context.Categories
                                .Include(c => c.GroupingList)
                                .ThenInclude(p => p.Product)
                                .ToList(),
                ProductList = _context.Products.ToList()
            };
            return View(view);
        }

        [HttpGet]
        [Route("Products/{id}")]
        public IActionResult ProductProfile(int id)
        {
            ViewModel view = new ViewModel(){
                Category = new Categories(),
                Product = _context.Products.SingleOrDefault(p => p.Id == id),
                Groupings = new Groupings(),
                ProductList = _context.Products
                                .Include(p => p.GroupingList)
                                .ThenInclude(g => g.Category)
                                .ToList(),
                CategoryList = _context.Categories.ToList()
            };
            return View(view);
        }
        [HttpPost]
        [Route("CreateGrouping/{id}")]
        public IActionResult CreateGrouping(ViewModel FormData, int id)
        {
            Groupings newGrouping = new Groupings(){
                ProductId = FormData.Groupings.ProductId,
                Product = _context.Products.SingleOrDefault(p => p.Id == FormData.Groupings.ProductId),
                CategoryId = FormData.Groupings.CategoryId,
                Category = _context.Categories.SingleOrDefault(p => p.Id == FormData.Groupings.CategoryId),
            };
            _context.Groupings.Add(newGrouping);
            _context.SaveChanges();
            newGrouping.Category.GroupingList.Add(newGrouping);
            _context.SaveChanges();

            return RedirectToAction("ProductProfile", id);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
