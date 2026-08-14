using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRD.Models
{
    [Table("TrainingRecords")]
    public class TrainingModel
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

        // ค่าใช้จ่าย
        public decimal InstructorFee { get; set; }
        public decimal SnackFee { get; set; }
        public decimal StaffLunchFee { get; set; }
        public decimal InstructorLunchFee { get; set; }
        public decimal SouvenirFee { get; set; }
        public decimal OtherFee { get; set; }

        public decimal TotalFee => InstructorFee + SnackFee + StaffLunchFee + InstructorLunchFee + SouvenirFee + OtherFee;
        public decimal TotalExpense { get; set; }

        // ลบฟิลด์ PassedTestPercent, CourseEvaluationScore ฯลฯ ออกจากตารางนี้ทั้งหมด
    }
}