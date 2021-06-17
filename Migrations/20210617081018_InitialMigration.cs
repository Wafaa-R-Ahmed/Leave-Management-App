using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveReasons");

            migrationBuilder.DropColumn(
                name: "CurrentLeaveBalance",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "Reason_FK",
                table: "UserLeaves");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "UserLeaves",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingLeaveBalance",
                table: "UserLeaves",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "RemainingLeaveBalance",
                table: "UserLeaves");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentLeaveBalance",
                table: "UserLeaves",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Reason_FK",
                table: "UserLeaves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LeaveReasons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveReasons", x => x.ID);
                });
        }
    }
}
