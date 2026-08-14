using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRD.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrainingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QualityControlRecords",
                table: "QualityControlRecords");

            migrationBuilder.DropColumn(
                name: "CumulativeHours",
                table: "QualityControlRecords");

            migrationBuilder.DropColumn(
                name: "EvaluatedEmployeesAfter3Months",
                table: "QualityControlRecords");

            migrationBuilder.DropColumn(
                name: "FailedCriteriaCount",
                table: "QualityControlRecords");

            migrationBuilder.DropColumn(
                name: "NotEvaluatedCount",
                table: "QualityControlRecords");

            migrationBuilder.DropColumn(
                name: "PassedCriteriaCount",
                table: "QualityControlRecords");

            migrationBuilder.RenameTable(
                name: "QualityControlRecords",
                newName: "QualityRecords");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "TrainingRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "TrainingRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "TrainingRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "StaffEvaluationScore",
                table: "QualityRecords",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PassedTestPercent",
                table: "QualityRecords",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "InstructorEvaluationScore",
                table: "QualityRecords",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FailedTestPercent",
                table: "QualityRecords",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "QualityRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "QualityRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<decimal>(
                name: "CourseEvaluationScore",
                table: "QualityRecords",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "QualityRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualityRecords",
                table: "QualityRecords",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SafetyRecords",
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
                    Hours = table.Column<int>(type: "int", nullable: false),
                    CumulativeHours = table.Column<int>(type: "int", nullable: false),
                    InstructorFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SnackFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StaffLunchFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstructorLunchFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SouvenirFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[InstructorFee] + [SnackFee] + [StaffLunchFee] + [InstructorLunchFee] + [SouvenirFee] + [OtherFee]"),
                    EvaluatedStaffCount = table.Column<int>(type: "int", nullable: true),
                    PassedEvaluationCount = table.Column<int>(type: "int", nullable: true),
                    FailedEvaluationCount = table.Column<int>(type: "int", nullable: true),
                    UnevaluatedCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SafetyRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualityRecords",
                table: "QualityRecords");

            migrationBuilder.RenameTable(
                name: "QualityRecords",
                newName: "QualityControlRecords");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "TrainingRecords",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "TrainingRecords",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "TrainingRecords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "StaffEvaluationScore",
                table: "QualityControlRecords",
                type: "decimal(3,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PassedTestPercent",
                table: "QualityControlRecords",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InstructorEvaluationScore",
                table: "QualityControlRecords",
                type: "decimal(3,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FailedTestPercent",
                table: "QualityControlRecords",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "QualityControlRecords",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "QualityControlRecords",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CourseEvaluationScore",
                table: "QualityControlRecords",
                type: "decimal(3,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "QualityControlRecords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CumulativeHours",
                table: "QualityControlRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvaluatedEmployeesAfter3Months",
                table: "QualityControlRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FailedCriteriaCount",
                table: "QualityControlRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotEvaluatedCount",
                table: "QualityControlRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassedCriteriaCount",
                table: "QualityControlRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualityControlRecords",
                table: "QualityControlRecords",
                column: "Id");
        }
    }
}
