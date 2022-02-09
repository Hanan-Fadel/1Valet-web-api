using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1Valet_web_api.Migrations
{
    public partial class updateschem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceType");

            migrationBuilder.CreateIndex(
                name: "IX_Device_TypeId",
                table: "Device",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Type_TypeId",
                table: "Device",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Type_TypeId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_TypeId",
                table: "Device");

            migrationBuilder.CreateTable(
                name: "DeviceType",
                columns: table => new
                {
                    DevicesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceType", x => new { x.DevicesId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_DeviceType_Device_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceType_Type_TypesId",
                        column: x => x.TypesId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceType_TypesId",
                table: "DeviceType",
                column: "TypesId");
        }
    }
}
