using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mig_16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HelpTag",
                columns: table => new
                {
                    HelpsHelpId = table.Column<int>(type: "int", nullable: false),
                    TagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpTag", x => new { x.HelpsHelpId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_HelpTag_Helps_HelpsHelpId",
                        column: x => x.HelpsHelpId,
                        principalTable: "Helps",
                        principalColumn: "HelpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HelpTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HelpTag_TagsTagId",
                table: "HelpTag",
                column: "TagsTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HelpTag");
        }
    }
}
