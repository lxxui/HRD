using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRD.Models
{
    [Table("CapabilityRecords")] // ชื่อตารางในฐานข้อมูลสำหรับพัฒนาศักยภาพ
    public class CapabilityModel
    {
        public int Id { get; set; }

        // 📅 1. ข้อมูลทั่วไป
        public DateTime TrainingDate { get; set; }
        public string Category { get; set; } = string.Empty; // ประเภทหลักสูตร
        public string CourseName { get; set; } = string.Empty; // ชื่อหลักสูตร

        // 👥 2. ข้อมูลผู้เข้าอบรม
        public int MaleCount { get; set; }          // ชาย
        public int FemaleCount { get; set; }        // หญิง
        public int TotalAttendees { get; set; }     // รวมผู้เข้าอบรม

        // ⏱️ 3. ระยะเวลาและชั่วโมง
        public string Duration { get; set; } = string.Empty;  // ระยะเวลาจัดอบรม (เช่น 1 วัน, 2 วัน)

        [Column(TypeName = "decimal(18,2)")]
        public decimal Hours { get; set; }                    // จำนวนชั่วโมงฝึกอบรม

        [Column(TypeName = "decimal(18,2)")]
        public decimal CumulativeHours { get; set; }          // รวมชั่วโมงฝึกอบรมสะสม

        // 💰 4. งบประมาณและค่าใช้จ่าย
        [Column(TypeName = "decimal(18,2)")]
        public decimal InstructorFee { get; set; }      // ค่าจ้างวิทยากร

        [Column(TypeName = "decimal(18,2)")]
        public decimal SnackFee { get; set; }           // ค่าอาหารว่าง

        [Column(TypeName = "decimal(18,2)")]
        public decimal StaffLunchFee { get; set; }      // ค่าอาหารกลางวันพนักงาน

        [Column(TypeName = "decimal(18,2)")]
        public decimal InstructorLunchFee { get; set; } // ค่าอาหารกลางวันวิทยากร

        [Column(TypeName = "decimal(18,2)")]
        public decimal SouvenirFee { get; set; }        // ค่าของที่ระลึก

        [Column(TypeName = "decimal(18,2)")]
        public decimal OtherFee { get; set; }           // ค่าใช้จ่ายอื่นๆ

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalExpense { get; set; }       // รวมค่าใช้จ่ายทั้งหมด

        // 📝 5. ผลการทดสอบและการประเมิน
        [Column(TypeName = "decimal(5,2)")]
        public decimal? PassedTestPercent { get; set; }     // ผ่านการทดสอบ คิดเป็น %

        [Column(TypeName = "decimal(5,2)")]
        public decimal? FailedTestPercent { get; set; }     // ไม่ผ่าน คิดเป็น %

        [Column(TypeName = "decimal(3,2)")]
        public decimal? CourseEvaluationScore { get; set; } // ประเมินหลักสูตร

        [Column(TypeName = "decimal(3,2)")]
        public decimal? InstructorEvaluationScore { get; set; } // ประเมินวิทยากร

        [Column(TypeName = "decimal(3,2)")]
        public decimal? StaffEvaluationScore { get; set; } // ประเมินเจ้าหน้าที่

        // 📈 6. การติดตามผลหลังอบรม 3 เดือน
        public int? EvaluatedAfter3MonthsCount { get; set; } // จำนวนพนักงานได้รับการประเมินหลังอบรม 3 เดือน
        public int? PassedAfter3MonthsCount { get; set; }    // ผ่านเกณฑ์การประเมิน (3 เดือน)
        public int? FailedAfter3MonthsCount { get; set; }    // ไม่ผ่านเกณฑ์ (3 เดือน)
        public int? NotEvaluatedAfter3MonthsCount { get; set; } // ไม่ได้รับการประเมิน (3 เดือน)
    }
}