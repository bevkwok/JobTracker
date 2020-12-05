using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTracker.Migrations
{
    public partial class FifthMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequiredSkill",
                table: "Jobs",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(555) CHARACTER SET utf8mb4",
                oldMaxLength: 555,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobNote",
                table: "Jobs",
                type: "LONGTEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500) CHARACTER SET utf8mb4",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                table: "Jobs",
                type: "LONGTEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationLink",
                table: "Jobs",
                type: "LONGTEXT",
                maxLength: 555,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(555) CHARACTER SET utf8mb4",
                oldMaxLength: 555,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequiredSkill",
                table: "Jobs",
                type: "varchar(555) CHARACTER SET utf8mb4",
                maxLength: 555,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobNote",
                table: "Jobs",
                type: "varchar(500) CHARACTER SET utf8mb4",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "LONGTEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                table: "Jobs",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "LONGTEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationLink",
                table: "Jobs",
                type: "varchar(555) CHARACTER SET utf8mb4",
                maxLength: 555,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "LONGTEXT",
                oldMaxLength: 555,
                oldNullable: true);
        }
    }
}
