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

        private static int currentIssuesID = 0;
        private static readonly object lockedObject = new object();
        private Dictionary<int, object> formData = new Dictionary<int, object>();
    
        [HttpPost]
        public IActionResult SubmitReport(IFormCollection form)
        {
            string location = form["location"];
            string category = form["category"];
            string description = form["description"];
            IFormFileCollection attachments = form.Files;

            int issueId = GenerateIssueID();

            formData[issueId] = new ReportedIssues
            {
                IssueID = issueId,
                IssueLocation = location,
                IssueCategory = category,
                IssueDescription = description,
                IssueAttachments = attachments
            };

            // Process the attachments
            foreach (var file in attachments)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            return Json(new { success = true, message = "Report submitted successfully" });
        }

        private int GenerateIssueID()
        {
            lock (lockedObject)
            {
                return currentIssuesID++;
            }
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
