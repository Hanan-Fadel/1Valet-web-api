using Microsoft.EntityFrameworkCore.Migrations;

namespace _1Valet_web_api.Migrations
{
    public partial class AddDeviceTempfied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceTemp",
                table: "Device",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceTemp",
                table: "Device");
        }
    }
}
