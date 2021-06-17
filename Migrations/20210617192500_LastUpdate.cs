using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Migrations
{
    public partial class LastUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveReason",
                table: "LeaveReason");

            migrationBuilder.RenameTable(
                name: "LeaveReason",
                newName: "LeaveReasons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveReasons",
                table: "LeaveReasons",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveReasons",
                table: "LeaveReasons");

            migrationBuilder.RenameTable(
                name: "LeaveReasons",
                newName: "LeaveReason");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveReason",
                table: "LeaveReason",
                column: "Id");
        }
    }
}
