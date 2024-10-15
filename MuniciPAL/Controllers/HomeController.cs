using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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


        //popluating the table with data
        private List<AnnouncedEvents> events = new List<AnnouncedEvents>
            {
                new AnnouncedEvents { eventID = 1, eventDate = "2024-08-12", eventLocation = "Louve", eventFee = 150.00, eventCategory = "Festival" },
                new AnnouncedEvents { eventID = 2, eventDate = "2024-09-23", eventLocation = "NMB Stadium", eventFee = 250.00, eventCategory = "Music" },
                new AnnouncedEvents { eventID = 3, eventDate = "2024-12-22", eventLocation = "City Hall", eventFee = 50.00, eventCategory = "Art" },
                new AnnouncedEvents { eventID = 4, eventDate = "2024-11-15", eventLocation = "Kings Beach", eventFee = 5.00, eventCategory = "Clean Up" },
                new AnnouncedEvents { eventID = 5, eventDate = "2024-11-15", eventLocation = "Community Center", eventFee = 40.00, eventCategory = "Sports" }
            };
        private int GenerateIssueID()
        {
            lock (lockedObject)
            {
                return currentIssuesID++;
            }
        }
        
       [HttpGet]
        public IActionResult Index()
        {
            return View(events);
        }

        [HttpPost]
        public IActionResult Index(string searchTerm)
        {
            var filteredEvents = events
                .Where(e => e.eventDate.Contains(searchTerm) || e.eventCategory.Contains(searchTerm))
                .ToList();

            ViewBag.HasSearched = true; // Set the flag to indicate a search has been performed

            return View(filteredEvents);
        }

        public IActionResult Announcements()
        {
            return View(events);
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
