using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRD.Models
{
    [Table("SafetyRecords")] // ชื่อตารางในฐานข้อมูลสำหรับความปลอดภัย
    public class SafetyModel
    {
        public int Id { get; set; }
        public DateTime TrainingDate { get; set; }
        public string Category { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int MaleCount { get; set; }
        public int FemaleCount { get; set; }
        public int TotalAttendees { get; set; }
        public string Duration { get; set; } = string.Empty;
        public int Hours { get; set; }
        public int CumulativeHours { get; set; }

        // ค่าใช้จ่ายต่างๆ
        public decimal InstructorFee { get; set; }
        public decimal SnackFee { get; set; }
        public decimal StaffLunchFee { get; set; }
        public decimal InstructorLunchFee { get; set; }
        public decimal SouvenirFee { get; set; }
        public decimal OtherFee { get; set; }
        public decimal TotalExpense { get; set; }

        // ฟิลด์เฉพาะของความปลอดภัย (การประเมินผลติดตาม 3 เดือน)
        public int? EvaluatedStaffCount { get; set; }
        public int? PassedEvaluationCount { get; set; }
        public int? FailedEvaluationCount { get; set; }
        public int? UnevaluatedCount { get; set; }
    }
}