using Microsoft.AspNetCore.Mvc;

namespace MuniciPAL.Controllers
{
    public class AnnouncementsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
