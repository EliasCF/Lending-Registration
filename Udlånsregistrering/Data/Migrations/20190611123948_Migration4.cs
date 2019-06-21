using Microsoft.EntityFrameworkCore.Migrations;

namespace Udlånsregistrering.Data.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPR_Number",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CPR_Number",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
