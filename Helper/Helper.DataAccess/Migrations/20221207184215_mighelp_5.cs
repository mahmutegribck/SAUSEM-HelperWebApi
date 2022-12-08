using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mighelp_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Helps_Users_UserId",
                table: "Helps");

            migrationBuilder.DropIndex(
                name: "IX_Helps_UserId",
                table: "Helps");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Helps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Helps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Helps_UserId",
                table: "Helps",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Helps_Users_UserId",
                table: "Helps",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
