using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mighelp_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Helps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Helps_UserID",
                table: "Helps",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Helps_Users_UserID",
                table: "Helps",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Helps_Users_UserID",
                table: "Helps");

            migrationBuilder.DropIndex(
                name: "IX_Helps_UserID",
                table: "Helps");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Helps");
        }
    }
}
