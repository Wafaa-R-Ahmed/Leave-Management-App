using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Migrations
{
    public partial class UserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUser_FK",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "UserLeaves",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Employee_ID",
                table: "UserLeaves",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUser_ID",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLeaves_EmployeeID",
                table: "UserLeaves",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AppUserId",
                table: "Employees",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_AppUserId",
                table: "Employees",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLeaves_Employees_EmployeeID",
                table: "UserLeaves",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_AppUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLeaves_Employees_EmployeeID",
                table: "UserLeaves");

            migrationBuilder.DropIndex(
                name: "IX_UserLeaves_EmployeeID",
                table: "UserLeaves");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AppUserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "Employee_ID",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AppUser_ID",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser_FK",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
