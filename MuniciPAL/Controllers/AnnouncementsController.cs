using Microsoft.AspNetCore.Mvc;
using MuniciPAL.Models;
using System.Collections.Generic;

namespace MuniciPAL.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly ILogger<AnnouncementsController> _logger;
        public AnnouncementsController(ILogger<AnnouncementsController> logger)
        {
            _logger = logger;
        }
    
        private List<AnnouncedEvents> events = new List<AnnouncedEvents>();

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Announcements()
        {
            return View(events);
        }

        [HttpPost]
        public IActionResult Display()
        {
            events.Add(new AnnouncedEvents { eventID = events.Count + 1, eventName="Fury Futsal", eventDate = DateTime.Parse("2024-08-12"), eventLocation = "Kings Beach, Gqeberha", eventCategory = "LMA Sports Tournament", eventFee = 20.00 });

            return View("Announcements", events);
        }

       
    }
}
