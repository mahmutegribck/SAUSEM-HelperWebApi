using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Answers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_IdentityUserId",
                table: "Answers",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_IdentityUserId",
                table: "Answers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_IdentityUserId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_IdentityUserId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Answers");
        }
    }
}
