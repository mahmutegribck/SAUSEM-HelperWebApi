using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mig_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HelpDate",
                table: "Helps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpDate",
                table: "Helps");
        }
    }
}
