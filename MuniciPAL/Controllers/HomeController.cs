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
           
        
        //popluating the table with data
        private List<AnnouncedEvents> events = new List<AnnouncedEvents>
            {
                new AnnouncedEvents { eventID = 1, eventDate = DateTime.Parse("2023-01-21, 13:00"), eventLocation = "Community Hall", eventFee = 150.00, eventCategory = "Recreational", eventName= "Bingo Evening", isAnnounced=false },
                new AnnouncedEvents { eventID = 2, eventDate = DateTime.Parse("2023-02-04, 07:30"), eventLocation = "Las Vegas", eventFee = 50000.00, eventCategory = "Educational", eventName= "Mucho Loco", isAnnounced=false },
                new AnnouncedEvents { eventID = 3, eventDate = DateTime.Parse("2023-02-15, 15:30"), eventLocation = "Emirates Stadium", eventFee = 10050.00, eventCategory = "Sports", eventName= "EPL Final", isAnnounced=false },
                new AnnouncedEvents { eventID = 4, eventDate = DateTime.Parse("2023-03-11, 17:00"), eventLocation = "FNB Stadium", eventFee = 10050.00, eventCategory = "Sports", eventName= "EPL Final", isAnnounced=false },
                new AnnouncedEvents { eventID = 5, eventDate = DateTime.Parse("2024-08-12, 11:11"), eventLocation = "Louve", eventFee = 12000050.00, eventCategory = "Celebration", eventName= "Love Evening", isAnnounced=false },
                new AnnouncedEvents { eventID = 6, eventDate = DateTime.Parse("2024-09-23, 09:00"), eventLocation = "NMB Stadium", eventFee = 250.00, eventCategory = "Music", eventName= "Sly Festive", isAnnounced=false},
                new AnnouncedEvents { eventID = 7, eventDate = DateTime.Parse("2024-11-22, 10:00"), eventLocation = "Fairview Sports Ground", eventFee = 250.00, eventCategory = "Community Building", eventName= "Bonanza", isAnnounced=true},
                new AnnouncedEvents { eventID = 8, eventDate = DateTime.Parse("2024-12-13, 13:00"), eventLocation = "City Hall", eventFee = 50.00, eventCategory = "Recreational", eventName= "Running Waters", isAnnounced=true },
                new AnnouncedEvents { eventID = 9, eventDate = DateTime.Parse("2024-12-22, 07:34"), eventLocation = "Eiffel Tower", eventFee = 50.00, eventCategory = "Art", eventName= "Sip and Paint", isAnnounced=true },
                new AnnouncedEvents { eventID = 10, eventDate = DateTime.Parse("2024-12-24,12:00"), eventLocation = "Kings Beach", eventFee = 5.00, eventCategory = "Community Building", eventName= "Kings Clean Up", isAnnounced=true },
                new AnnouncedEvents { eventID = 11, eventDate = DateTime.Parse("2024-12-25, 12:30"), eventLocation = "Community Center", eventFee = 40.00, eventCategory = "Festival", eventName= "Christmas Feast", isAnnounced=true },
                new AnnouncedEvents { eventID = 12, eventDate = DateTime.Parse("2025-01-01, 09:00"), eventLocation = "PVT Location", eventFee = 40.00, eventCategory = "Recreational", eventName= "Bingo Evening", isAnnounced=true }
            };
       

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
        
       [HttpGet]
        public IActionResult Index()
        {      
            return View(events);
        }

        [HttpPost]
        public IActionResult Index(string searchTerm)
        {
           
            searchTerm = Request.Form["searchTerm"];
          
                 
            ViewBag.HasSearched = true; // Set the flag to indicate a search has been performed

            return View(searchTerm);
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
