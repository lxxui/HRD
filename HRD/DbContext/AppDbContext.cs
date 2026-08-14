using HRD.Models;
using Microsoft.EntityFrameworkCore;
using static HRD.Models.TrainingModel;

namespace HRD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // ตารางเดิม (บันทึกการฝึกอบรมทั่วไป)
        public DbSet<TrainingModel> TrainingRecords { get; set; }

        // ตารางระบบคุณภาพ
        public DbSet<QualityModel> QualityRecords { get; set; }

        // ตารางความปลอดภัย
        public DbSet<SafetyModel> SafetyRecords { get; set; }

        // ตารางพัฒนาศักยภาพ
        public DbSet<CapabilityModel> CapabilityRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==========================================
            // 1. ตั้งค่า Precision สำหรับทุกฟิลด์ที่เป็น decimal
            // ==========================================
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var decimalProperties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

                foreach (var property in decimalProperties)
                {
                    // ตั้งค่า default precision เป็น (18, 2) ให้ทุก decimal ในโปรเจกต์อัตโนมัติ
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }

            // ==========================================
            // 2. ตั้งค่า Computed Column
            // ==========================================

            // TrainingRecords
            modelBuilder.Entity<TrainingModel>()
                .Property(t => t.TotalAttendees)
                .HasComputedColumnSql("[MaleCount] + [FemaleCount]");

            modelBuilder.Entity<TrainingModel>()
                .Property(t => t.TotalExpense)
                .HasComputedColumnSql("[InstructorFee] + [SnackFee] + [StaffLunchFee] + [InstructorLunchFee] + [SouvenirFee] + [OtherFee]");

            // QualityRecords
            modelBuilder.Entity<QualityModel>()
                .Property(q => q.TotalAttendees)
                .HasComputedColumnSql("[MaleCount] + [FemaleCount]");

            modelBuilder.Entity<QualityModel>()
                .Property(q => q.TotalExpense)
                .HasComputedColumnSql("[InstructorFee] + [SnackFee] + [StaffLunchFee] + [InstructorLunchFee] + [SouvenirFee] + [OtherFee]");

            // SafetyRecords
            modelBuilder.Entity<SafetyModel>()
                .Property(s => s.TotalAttendees)
                .HasComputedColumnSql("[MaleCount] + [FemaleCount]");

            modelBuilder.Entity<SafetyModel>()
                .Property(s => s.TotalExpense)
                .HasComputedColumnSql("[InstructorFee] + [SnackFee] + [StaffLunchFee] + [InstructorLunchFee] + [SouvenirFee] + [OtherFee]");

            // CapabilityRecords
            modelBuilder.Entity<CapabilityModel>()
                .Property(s => s.TotalAttendees)
                .HasComputedColumnSql("[MaleCount] + [FemaleCount]");

            modelBuilder.Entity<CapabilityModel>()
                .Property(s => s.TotalExpense)
                .HasComputedColumnSql("[InstructorFee] + [SnackFee] + [StaffLunchFee] + [InstructorLunchFee] + [SouvenirFee] + [OtherFee]");
        }
    }
}