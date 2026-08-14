using HRD.Data;
using HRD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRD.Controllers
{
    public class TrainingController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string tab = "orientation")
        {
            ViewData["ActiveTab"] = tab;

            if (tab == "quality")
            {
                var qualityList = await _context.QualityRecords
                    .OrderByDescending(x => x.TrainingDate)
                    .ToListAsync();
                return View(qualityList);
            }
            else if (tab == "safety")
            {
                var safetyList = await _context.SafetyRecords
                    .OrderByDescending(x => x.TrainingDate)
                    .ToListAsync();
                return View(safetyList);
            }
            else if (tab == "development") // 👈 เพิ่มส่วนนี้สำหรับแท็บพัฒนาศักยภาพ
            {
                var capabilityList = await _context.CapabilityRecords
                    .OrderByDescending(x => x.TrainingDate)
                    .ToListAsync();
                return View(capabilityList);
            }
            else
            {
                var trainingList = await _context.TrainingRecords
                    .Where(x => x.Category == tab)
                    .OrderByDescending(x => x.TrainingDate)
                    .ToListAsync();
                return View(trainingList);
            }
        }

        // บันทึกข้อมูลการอบรมทั่วไป (สำหรับแท็บอื่นๆ)
        [HttpPost]
        public async Task<IActionResult> SaveTraining(TrainingModel model)
        {
            if (ModelState.IsValid)
            {
                _context.TrainingRecords.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { tab = model.Category });
            }
            return RedirectToAction("Index", new { tab = model.Category });
        }

        // บันทึกข้อมูลระบบคุณภาพ
        [HttpPost]
        public async Task<IActionResult> SaveQualityRecord(QualityModel model)
        {
            if (ModelState.IsValid)
            {
                model.Category = "quality";
                _context.QualityRecords.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { tab = "quality" });
            }
            return RedirectToAction("Index", new { tab = "quality" });
        }
    }
}