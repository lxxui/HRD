using Microsoft.AspNetCore.Mvc;

namespace HRD.Controllers
{
    public class ElearningController : Controller
    {
        // GET: /Elearning
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Elearning/Certificate
        // รองรับการส่ง courseCode มาเพื่อ Auto-select หลักสูตรในฟอร์มให้อัตโนมัติ
        public IActionResult Certificate(string courseCode = null)
        {
            ViewBag.SelectedCourseCode = courseCode;
            return View();
        }

        // POST: /Elearning/RequestCertificate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RequestCertificate(string empId, string fullName, string courseCode, string deliveryChannel)
        {
            // TODO: Logic สำหรับตรวจสอบสิทธิ์ และออก Certificate PDF / ส่ง Email

            TempData["SuccessMessage"] = "ยื่นคำร้องขอรับวุฒิบัตรเรียบร้อยแล้ว ระบบกำลังจัดส่งไปยังช่องทางที่เลือก";
            return RedirectToAction(nameof(Certificate));
        }
    }
}