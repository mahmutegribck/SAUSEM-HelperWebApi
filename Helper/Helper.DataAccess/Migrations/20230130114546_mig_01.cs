using Microsoft.EntityFrameworkCore.Migrations;

namespace Helper.DataAccess.Migrations
{
    public partial class mig_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1fc2342-4222-47f4-bdfb-c52fdb6f8dd4", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAENLVnmy9x4H1au+wejO90wVVqM0iaxV40uy/hCYZEgMYfqMQynpBRfvkPQanRYngqw==", "d5129dbe-37d2-41ff-a284-a3b20fc806c6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3422c2ac-3355-489e-b341-fc004a2c8c63", null, null, "AQAAAAEAACcQAAAAEJtODi/AZOI1AyH2z7sGwGcExTWn9N/0+BGuBvbhT4iHPobI6EnaMYex+QPYKUPzYA==", null });
        }
    }
}
