using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRD.Migrations
{
    /// <inheritdoc />
    public partial class AddCapabilityAndFixDecimals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapabilityRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaleCount = table.Column<int>(type: "int", nullable: false),
                    FemaleCount = table.Column<int>(type: "int", nullable: false),
                    TotalAttendees = table.Column<int>(type: "int", nullable: false, computedColumnSql: "[MaleCount] + [FemaleCount]"),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CumulativeHours = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InstructorFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SnackFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StaffLunchFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InstructorLunchFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SouvenirFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OtherFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalExpense = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, computedColumnSql: "[InstructorFee] + [SnackFee] + [StaffLunchFee] + [InstructorLunchFee] + [SouvenirFee] + [OtherFee]"),
                    PassedTestPercent = table.Column<decimal>(type: "decimal(5,2)", precision: 18, scale: 2, nullable: true),
                    FailedTestPercent = table.Column<decimal>(type: "decimal(5,2)", precision: 18, scale: 2, nullable: true),
                    CourseEvaluationScore = table.Column<decimal>(type: "decimal(3,2)", precision: 18, scale: 2, nullable: true),
                    InstructorEvaluationScore = table.Column<decimal>(type: "decimal(3,2)", precision: 18, scale: 2, nullable: true),
                    StaffEvaluationScore = table.Column<decimal>(type: "decimal(3,2)", precision: 18, scale: 2, nullable: true),
                    EvaluatedAfter3MonthsCount = table.Column<int>(type: "int", nullable: true),
                    PassedAfter3MonthsCount = table.Column<int>(type: "int", nullable: true),
                    FailedAfter3MonthsCount = table.Column<int>(type: "int", nullable: true),
                    NotEvaluatedAfter3MonthsCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilityRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapabilityRecords");
        }
    }
}
