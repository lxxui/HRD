using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YourProjectName.Controllers
{
    public class OjtController : Controller
    {
        // ==========================================
        // 1. DASHBOARD & OVERVIEW
        // ==========================================

        /// <summary>
        /// แสดงหน้าหลัก Dashboard รายการแผนงาน OJT และ Checklist การฝึกงาน
        /// GET: /Ojt
        /// </summary>
        [HttpGet]
        public IActionResult Index(string searchEmp = "", string statusFilter = "")
        {
            // Summary Statistics (สำหรับ KPI Cards)
            ViewBag.ActiveOjtCount = 12;
            ViewBag.TraineeCount = 8;
            ViewBag.PendingEvalCount = 3;
            ViewBag.PassedCount = 15;

            // Search & Filter Metadata (เผื่อใช้หน้า UI)
            ViewData["CurrentSearch"] = searchEmp;
            ViewData["CurrentStatus"] = statusFilter;

            return View();
        }

        // ==========================================
        // 2. OJT PLAN CREATION
        // ==========================================

        /// <summary>
        /// สร้างแผนงาน OJT ใหม่ (รองรับทั้ง Form Submit และ AJAX)
        /// POST: /Ojt/Create
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [FromForm] string empId,
            [FromForm] string traineeName,
            [FromForm] string mentorName,
            [FromForm] string courseTitle,
            [FromForm] DateTime? startDate,
            [FromForm] int durationDays = 30)
        {
            // Server-side Basic Validation
            if (string.IsNullOrWhiteSpace(traineeName) || string.IsNullOrWhiteSpace(courseTitle))
            {
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = false, message = "กรุณากรอกข้อมูลพนักงานและหลักสูตรให้ครบถ้วน" });
                }

                TempData["ErrorMessage"] = "กรุณากรอกข้อมูลสำคัญให้ครบถ้วน";
                return RedirectToAction(nameof(Index));
            }

            // TODO: EF Core Save Data Example:
            // var newPlan = new OjtPlan { EmpId = empId, TraineeName = traineeName, ... };
            // _context.OjtPlans.Add(newPlan);
            // await _context.SaveChangesAsync();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = true, message = "สร้างแผน OJT เรียบร้อยแล้ว!" });
            }

            TempData["SuccessMessage"] = $"สร้างแผน OJT สำหรับคุณ {traineeName} เรียบร้อยแล้ว!";
            return RedirectToAction(nameof(Index));
        }

        // ==========================================
        // 3. TASK EVALUATION & PROGRESS TRACKING
        // ==========================================

        /// <summary>
        /// บันทึกผลการประเมิน Task แต่ละหัวข้อโดย Mentor
        /// POST: /Ojt/EvaluateTask
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EvaluateTask(int taskId, string status, string comment)
        {
            if (taskId <= 0 || string.IsNullOrEmpty(status))
            {
                return Json(new { success = false, message = "ข้อมูลการประเมินไม่ถูกต้อง" });
            }

            // TODO: อัปเดตสถานะใน DB (เช่น status: Passed, Pending, Retry)
            // var task = _context.OjtTasks.Find(taskId);
            // task.Status = status;
            // task.EvaluatedAt = DateTime.Now;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = true, message = "บันทึกผลการประเมินสำเร็จ", taskId, status });
            }

            TempData["SuccessMessage"] = "บันทึกผลการประเมินสำเร็จ";
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// เพิ่มบันทึกข้อเสนอแนะจาก Mentor
        /// POST: /Ojt/AddMentorNote
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMentorNote(int ojtId, string note)
        {
            if (string.IsNullOrWhiteSpace(note))
            {
                TempData["ErrorMessage"] = "กรุณากรอกข้อเสนอแนะก่อนบันทึก";
                return RedirectToAction(nameof(Index));
            }

            // TODO: บันทึก Note ลง DB

            TempData["SuccessMessage"] = "บันทึกข้อเสนอแนะจาก Mentor เรียบร้อยแล้ว";
            return RedirectToAction(nameof(Index));
        }

        // ==========================================
        // 4. DETAILS & REPORT
        // ==========================================

        /// <summary>
        /// ดูรายละเอียดและประวัติ OJT รายบุคคล
        /// GET: /Ojt/Details/5
        /// </summary>
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            ViewBag.OjtId = id;
            return View();
        }
    }
}