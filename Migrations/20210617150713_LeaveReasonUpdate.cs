using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Migrations
{
    public partial class LeaveReasonUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "UserLeaves",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "UserLeaves",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "LeaveReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveReason", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LeaveReason",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Annual Vacation" },
                    { 2, "Sick Leave" },
                    { 3, "Maternity Leave" },
                    { 4, "Unpaid Leave" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveReason");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "UserLeaves");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "UserLeaves",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
