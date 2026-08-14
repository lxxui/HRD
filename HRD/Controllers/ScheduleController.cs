using Microsoft.AspNetCore.Mvc;

namespace HRD.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
