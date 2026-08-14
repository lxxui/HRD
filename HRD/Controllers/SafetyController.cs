using Microsoft.AspNetCore.Mvc;

namespace HRD.Controllers
{
    public class SafetyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
