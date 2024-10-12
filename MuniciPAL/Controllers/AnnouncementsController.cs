using Microsoft.AspNetCore.Mvc;
using MuniciPAL.Models;

namespace MuniciPAL.Controllers
{
    public class AnnouncementsController : Controller
    {
         private readonly IWebHostEnvironment _webHostEnvironment;

        public AnnouncementsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public HashSet<AnnouncedEvents> events = new HashSet<AnnouncedEvents>();

        
        [HttpPost]
        public IActionResult Display()
        {
           
            HashSet<String> eventDates = new HashSet<String>();
            eventDates.Add("12 / 08 / 2024");
            eventDates.Add("23 / 09 / 2024");
            eventDates.Add("03 / 10 / 2024");
            eventDates.Add("13 / 12 / 2024");
            eventDates.Add("21 / 12 / 2024");
            eventDates.Add("22 / 12 / 2024");
            eventDates.Add("24 / 12 / 2024");
            eventDates.Add("09 / 01 / 2025");
            eventDates.Add("04 / 02 / 2025");
            eventDates.Add("15 / 02 / 2025");
            eventDates.Add("11 / 03 / 2025");
            
            HashSet<String> eventLocations = new HashSet<String>();
            eventLocations.Add("Hobbie Beach, Summerstrand");
            eventLocations.Add("Baywest Mall, Bridgemead");
            eventLocations.Add("Greenacres Mall, Greenacres");
            eventLocations.Add("Varsity College NMB, Greenacres");
            eventLocations.Add("Nelson Mandela Stadium, Gqeberha");
            eventLocations.Add("Emirates Stadium, London");
            eventLocations.Add("Dan Qeqe, Zwide");
            eventLocations.Add("Kings Beach, Summerstrand");
            eventLocations.Add("PVT Location");
            eventLocations.Add("TBC");
            eventLocations.Add("TBC");
            
            HashSet<String> eventThemes = new HashSet<String>();
            eventThemes.Add("Black & Gold");
            eventThemes.Add("Halloween");
            eventThemes.Add("Dress-2-Impress");
            eventThemes.Add("Love Is The Air");
            eventThemes.Add("Football-Fanatic");
            eventThemes.Add("TBC");
            eventThemes.Add("All-White");
            eventThemes.Add("Diddy-Combs-Type");
            eventThemes.Add("All Red");
            eventThemes.Add("Gamers Garments");
            eventThemes.Add("TBC");
            
            HashSet<Double> eventFees = new HashSet<double>();
            eventFees.Add(250.00);
            eventFees.Add(50.00);
            eventFees.Add(5550.00);
            eventFees.Add(7250.00);
            eventFees.Add(0.00);
            eventFees.Add(150.00);
            eventFees.Add(500.00);
            eventFees.Add(1500.00);
            eventFees.Add(10000.00);
            eventFees.Add(22000.00);
            eventFees.Add(0.00);

            foreach(var date in eventDates)
            {
                foreach(var location in eventLocations) 
                { 
                    foreach(var fee in eventFees)
                    {
                        foreach(var theme in eventThemes)
                        {
                            
                            events.Add(new AnnouncedEvents
                            {
                                eventID = events.Count +1,
                                eventDate = date,
                                eventLocation = location,
                                eventFee = fee,
                                eventTheme = theme,
                            });
                        }
                    }
                }
            };
            
              // Check if the model is null or empty
                if (events == null || !events.Any())
                {
                    throw new InvalidOperationException("AnnouncedEvents model is null or empty.");
                }

            return RedirectToAction("Index");
        }

        
        public IActionResult Index()
        {
            return View(events);
        }

    }
}
