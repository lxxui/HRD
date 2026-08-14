using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRD.Models
{
    [Table("QualityRecords")]
    public class QualityModel
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

        // ค่าใช้จ่าย
        public decimal InstructorFee { get; set; }
        public decimal SnackFee { get; set; }
        public decimal StaffLunchFee { get; set; }
        public decimal InstructorLunchFee { get; set; }
        public decimal SouvenirFee { get; set; }
        public decimal OtherFee { get; set; }
        public decimal TotalExpense { get; set; }

        // ฟิลด์เฉพาะระบบคุณภาพ
        public decimal? PassedTestPercent { get; set; }
        public decimal? FailedTestPercent { get; set; }
        public decimal? CourseEvaluationScore { get; set; }
        public decimal? InstructorEvaluationScore { get; set; }
        public decimal? StaffEvaluationScore { get; set; }
    }
}