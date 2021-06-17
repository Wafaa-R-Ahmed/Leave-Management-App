using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Migrations
{
    public partial class DBSchemaChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLeaves_Employees_EmployeeId",
                table: "UserLeaves");

            migrationBuilder.DropIndex(
                name: "IX_UserLeaves_EmployeeId",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "UserLeaves");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "UserLeaves",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UserLeaves",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LeaveBalance",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_UserLeaves_ApplicationUserId1",
                table: "UserLeaves",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLeaves_AspNetUsers_ApplicationUserId1",
                table: "UserLeaves",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLeaves_AspNetUsers_ApplicationUserId1",
                table: "UserLeaves");

            migrationBuilder.DropIndex(
                name: "IX_UserLeaves_ApplicationUserId1",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "LeaveBalance",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "UserLeaves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLeaves_EmployeeId",
                table: "UserLeaves",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLeaves_Employees_EmployeeId",
                table: "UserLeaves",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
