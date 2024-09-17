using Microsoft.AspNetCore.Mvc;
using MuniciPAL.Models;
using System.Diagnostics;

namespace MuniciPAL.Controllers
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
            return View();
        }
         public IActionResult Announcements()
        {
            return View();
        }

        public IActionResult ReportIssues()
        {
            return View();
        }

        public IActionResult ServiceRequestStatus()
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
