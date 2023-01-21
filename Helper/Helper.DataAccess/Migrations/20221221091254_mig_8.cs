using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mig_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Helps_HelpId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_HelpId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "HelpId",
                table: "Answers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HelpId",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_HelpId",
                table: "Answers",
                column: "HelpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Helps_HelpId",
                table: "Answers",
                column: "HelpId",
                principalTable: "Helps",
                principalColumn: "HelpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
