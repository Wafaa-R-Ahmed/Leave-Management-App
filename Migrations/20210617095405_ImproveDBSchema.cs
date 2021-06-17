using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Migrations
{
    public partial class ImproveDBSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLeaves_Employees_EmployeeID",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "Employee_ID",
                table: "UserLeaves");

            migrationBuilder.DropColumn(
                name: "AppUser_ID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "UserLeaves",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLeaves_EmployeeID",
                table: "UserLeaves",
                newName: "IX_UserLeaves_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "UserLeaves",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLeaves_Employees_EmployeeId",
                table: "UserLeaves",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLeaves_Employees_EmployeeId",
                table: "UserLeaves");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "UserLeaves",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_UserLeaves_EmployeeId",
                table: "UserLeaves",
                newName: "IX_UserLeaves_EmployeeID");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "UserLeaves",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Employee_ID",
                table: "UserLeaves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUser_ID",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLeaves_Employees_EmployeeID",
                table: "UserLeaves",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
