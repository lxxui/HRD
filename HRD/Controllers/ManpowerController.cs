using Microsoft.AspNetCore.Mvc;

namespace HRD.Controllers
{
    public class ManpowerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
