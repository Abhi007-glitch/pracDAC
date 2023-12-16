using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1MVC.Models;

namespace WebApplication1MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; // constructor based dependency injection 
        }

        //***************** ACTION METHODS - method 

        // 
        // receving via query string  -> not necessary to pass all the values in query string 
        // Home/Index/1?a=10&b=20
        // Home/Index/1?b=20  
        public IActionResult Index(int? id, int a , int b)
        {
            ViewBag.Id = id;  // 
            ViewBag.A = a;
            ViewBag.B = b;
            
            return View(); // return a view matching method name Index with small first letter (index.cshtml)
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
