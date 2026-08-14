using Microsoft.AspNetCore.Mvc;

namespace HRD.Controllers
{
    public class RiskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
