using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTracker.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                table: "Jobs",
                maxLength: 555,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "LONGTEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                table: "Jobs",
                type: "LONGTEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 555,
                oldNullable: true);
        }
    }
}
