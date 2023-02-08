using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mig_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5603e2ad-9026-4251-b973-3202ccfc304c", "AQAAAAEAACcQAAAAEOycWDP6w6nXW7ENpjkp2bWc+9E2TNW2GKMakIA0xCn7qHG3LOPXn14BvQa+D0H0sw==", "d5f90022-80d1-4df8-805c-e521bc188d5b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bbd7567-5299-4992-b7e1-7fa2871534c6", "AQAAAAEAACcQAAAAEKR9Zm17YUX2tJ4zvYZJFUNWdCiZbAT4BHjzPYW51T1DCEGKWCNRS4HNiYDYiKj1Rw==", "a99eec43-6bd4-43c1-b5b9-47946eb3aff0" });
        }
    }
}
