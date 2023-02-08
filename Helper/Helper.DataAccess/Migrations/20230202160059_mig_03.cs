using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mig_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpTag",
                table: "Helps");

            migrationBuilder.DropColumn(
                name: "AnswerCheck",
                table: "Answers");

            migrationBuilder.AddColumn<bool>(
                name: "HelpCheck",
                table: "Helps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bbd7567-5299-4992-b7e1-7fa2871534c6", "AQAAAAEAACcQAAAAEKR9Zm17YUX2tJ4zvYZJFUNWdCiZbAT4BHjzPYW51T1DCEGKWCNRS4HNiYDYiKj1Rw==", "a99eec43-6bd4-43c1-b5b9-47946eb3aff0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpCheck",
                table: "Helps");

            migrationBuilder.AddColumn<string>(
                name: "HelpTag",
                table: "Helps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerCheck",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "deb9138b-59fe-4e52-9606-8668fce5434d", "AQAAAAEAACcQAAAAEO9FlhrF6iTHai+cpJxqdkjSzXOwAiuqz1ZpM3pp8AcabvRZ8NGwT3FN3HHxAfWewg==", "5c102fb6-3836-4c3b-ae4d-1057878f2a65" });
        }
    }
}
