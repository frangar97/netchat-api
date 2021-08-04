using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Channel",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("eeaa59c5-ec84-4980-86fa-4286caa39b4e"), "Canal dedicado a net core", "Net Core" });

            migrationBuilder.InsertData(
                table: "Channel",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("be5a1a76-5fe4-4036-82f5-3244a6e792f3"), "Canal dedicado a ReactJs", "ReactJs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("be5a1a76-5fe4-4036-82f5-3244a6e792f3"));

            migrationBuilder.DeleteData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("eeaa59c5-ec84-4980-86fa-4286caa39b4e"));
        }
    }
}
