using Microsoft.AspNetCore.Mvc;
using Session.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
namespace Session.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("name", "hamza khan");
            //HttpContext.Session.GetString("name");
            return View();
        }

        public IActionResult Details()
        {
            if (HttpContext.Session.GetString("name") != null) {
                ViewBag.data = HttpContext.Session.GetString("name").ToString();
            }
            return View();
        }
        public IActionResult Details2()
        {
            if (HttpContext.Session.GetString("name") != null)
            {
                ViewBag.data = HttpContext.Session.GetString("name").ToString();
            }
            return View();
        }
        //accessing session directly in view
        public IActionResult Details3()
        {
            //Cheking null because if we remove session and then want to get again 
            // function then it will get error
            if (HttpContext.Session.GetString("name") != null)
            {
                ViewBag.data = HttpContext.Session.GetString("name").ToString();
            }
            return View();
        }
        public IActionResult Lgout()
        {
            HttpContext.Session.Remove("name");
            return View();
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
