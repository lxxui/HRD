using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRD.Migrations
{
    /// <inheritdoc />
    public partial class AddQualityControlTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityControlRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaleCount = table.Column<int>(type: "int", nullable: false),
                    FemaleCount = table.Column<int>(type: "int", nullable: false),
                    TotalAttendees = table.Column<int>(type: "int", nullable: false, computedColumnSql: "[MaleCount] + [FemaleCount]"),
                    Duration = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    CumulativeHours = table.Column<int>(type: "int", nullable: false),
                    InstructorFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SnackFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StaffLunchFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstructorLunchFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SouvenirFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[InstructorFee] + [SnackFee] + [StaffLunchFee] + [InstructorLunchFee] + [SouvenirFee] + [OtherFee]"),
                    PassedTestPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    FailedTestPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CourseEvaluationScore = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    InstructorEvaluationScore = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    StaffEvaluationScore = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    EvaluatedEmployeesAfter3Months = table.Column<int>(type: "int", nullable: false),
                    PassedCriteriaCount = table.Column<int>(type: "int", nullable: false),
                    FailedCriteriaCount = table.Column<int>(type: "int", nullable: false),
                    NotEvaluatedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityControlRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityControlRecords");
        }
    }
}
