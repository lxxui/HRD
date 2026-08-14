using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRD.Migrations
{
    /// <inheritdoc />
    public partial class InitialTrainingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingRecords",
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
                    Duration = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    CumulativeHours = table.Column<int>(type: "int", nullable: false),
                    InstructorFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SnackFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StaffLunchFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstructorLunchFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SouvenirFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[InstructorFee] + [SnackFee] + [StaffLunchFee] + [InstructorLunchFee] + [SouvenirFee] + [OtherFee]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingRecords");
        }
    }
}
