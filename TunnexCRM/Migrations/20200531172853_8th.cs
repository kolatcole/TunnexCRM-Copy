using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Presentation.Core.Migrations
{
    public partial class _8th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Qualifications_QualificationID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_QualificationID",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "QualificationID",
                table: "Staffs");

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "Qualifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_StaffID",
                table: "Qualifications",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_Staffs_StaffID",
                table: "Qualifications",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_Staffs_StaffID",
                table: "Qualifications");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_StaffID",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "Qualifications");

            migrationBuilder.AddColumn<int>(
                name: "QualificationID",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_QualificationID",
                table: "Staffs",
                column: "QualificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Qualifications_QualificationID",
                table: "Staffs",
                column: "QualificationID",
                principalTable: "Qualifications",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
