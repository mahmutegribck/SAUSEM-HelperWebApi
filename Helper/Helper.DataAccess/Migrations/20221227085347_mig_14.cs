using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mig_14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Helps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Helps_CategoryId",
                table: "Helps",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Helps_Categories_CategoryId",
                table: "Helps",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Helps_Categories_CategoryId",
                table: "Helps");

            migrationBuilder.DropIndex(
                name: "IX_Helps_CategoryId",
                table: "Helps");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Helps");
        }
    }
}
