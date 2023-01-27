using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mig_22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_IdentityUserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Helps_AspNetUsers_IdentityUserId",
                table: "Helps");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Helps",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Helps_IdentityUserId",
                table: "Helps",
                newName: "IX_Helps_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Answers",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_IdentityUserId",
                table: "Answers",
                newName: "IX_Answers_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_ApplicationUserId",
                table: "Answers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Helps_AspNetUsers_ApplicationUserId",
                table: "Helps",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_ApplicationUserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Helps_AspNetUsers_ApplicationUserId",
                table: "Helps");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Helps",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Helps_ApplicationUserId",
                table: "Helps",
                newName: "IX_Helps_IdentityUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Answers",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_ApplicationUserId",
                table: "Answers",
                newName: "IX_Answers_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_IdentityUserId",
                table: "Answers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Helps_AspNetUsers_IdentityUserId",
                table: "Helps",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
