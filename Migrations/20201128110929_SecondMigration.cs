using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTracker.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Jobs_JobId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FromCompany",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Jobs_JobId",
                table: "Contacts",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Jobs_JobId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "FromCompany",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Contacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Jobs_JobId",
                table: "Contacts",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
