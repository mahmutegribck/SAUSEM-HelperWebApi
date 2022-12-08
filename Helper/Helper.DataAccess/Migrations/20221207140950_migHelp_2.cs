using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class migHelp_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Help_Users_UserId",
                table: "Help");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Help",
                table: "Help");

            migrationBuilder.RenameTable(
                name: "Help",
                newName: "Helps");

            migrationBuilder.RenameIndex(
                name: "IX_Help_UserId",
                table: "Helps",
                newName: "IX_Helps_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Helps",
                table: "Helps",
                column: "HelpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Helps_Users_UserId",
                table: "Helps",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Helps_Users_UserId",
                table: "Helps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Helps",
                table: "Helps");

            migrationBuilder.RenameTable(
                name: "Helps",
                newName: "Help");

            migrationBuilder.RenameIndex(
                name: "IX_Helps_UserId",
                table: "Help",
                newName: "IX_Help_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Help",
                table: "Help",
                column: "HelpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Help_Users_UserId",
                table: "Help",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
