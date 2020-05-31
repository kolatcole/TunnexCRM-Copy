using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Presentation.Core.Migrations
{
    public partial class ist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Skills");
            migrationBuilder.DropTable(
              name: "Messages");

            migrationBuilder.CreateTable(
                name: "Competencies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetValue = table.Column<decimal>(nullable: false),
                    ActualValue = table.Column<decimal>(nullable: false),
                    CompPercent = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencies", x => x.ID);
                });

           


            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.ID);
                });

          

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreated = table.Column<int>(nullable: false),
                    UserModified = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    LeadID = table.Column<int>(nullable: false),
                    Attachment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_Leads_LeadID",
                        column: x => x.LeadID,
                        principalTable: "Leads",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreated = table.Column<int>(nullable: false),
                    UserModified = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HEL = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    QualificationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staffs_Qualifications_QualificationID",
                        column: x => x.QualificationID,
                        principalTable: "Qualifications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

         

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreated = table.Column<int>(nullable: false),
                    UserModified = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DueDay = table.Column<DateTime>(nullable: false),
                    SupervisorID = table.Column<int>(nullable: false),
                    CompetencyID = table.Column<int>(nullable: true),
                    StaffID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Skills_Competencies_CompetencyID",
                        column: x => x.CompetencyID,
                        principalTable: "Competencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_AppUsers_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "AppUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

           
            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAS = table.Column<int>(nullable: false),
                    SKAS = table.Column<int>(nullable: false),
                    IAS = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SkillID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assessments_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_SkillID",
                table: "Assessments",
                column: "SkillID");

          

            migrationBuilder.CreateIndex(
                name: "IX_Messages_LeadID",
                table: "Messages",
                column: "LeadID");

          

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CompetencyID",
                table: "Skills",
                column: "CompetencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StaffID",
                table: "Skills",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SupervisorID",
                table: "Skills",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_QualificationID",
                table: "Staffs",
                column: "QualificationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Privileges");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Competencies");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
