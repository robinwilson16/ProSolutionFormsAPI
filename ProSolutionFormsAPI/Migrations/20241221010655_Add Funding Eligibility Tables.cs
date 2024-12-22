using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFundingEligibilityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundingEligibilityDeclaration",
                columns: table => new
                {
                    FundingEligibilityDeclarationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeExemptionReasonID = table.Column<int>(type: "int", nullable: true),
                    FeeExemptionReasonOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignedStudent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignedStudentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentDetailID = table.Column<int>(type: "int", nullable: true),
                    AcademicYearID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingEligibilityDeclaration", x => x.FundingEligibilityDeclarationID);
                });

            migrationBuilder.CreateTable(
                name: "FundingEligibilityDeclarationEvidence",
                columns: table => new
                {
                    FundingEligibilityDeclarationEvidenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingEligibilityDeclarationID = table.Column<int>(type: "int", nullable: true),
                    EvidenceType = table.Column<int>(type: "int", nullable: false),
                    Evidence = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingEligibilityDeclarationEvidence", x => x.FundingEligibilityDeclarationEvidenceID);
                    table.ForeignKey(
                        name: "FK_FundingEligibilityDeclarationEvidence_FundingEligibilityDeclaration_FundingEligibilityDeclarationID",
                        column: x => x.FundingEligibilityDeclarationID,
                        principalTable: "FundingEligibilityDeclaration",
                        principalColumn: "FundingEligibilityDeclarationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundingEligibilityDeclarationEvidence_FundingEligibilityDeclarationID",
                table: "FundingEligibilityDeclarationEvidence",
                column: "FundingEligibilityDeclarationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundingEligibilityDeclarationEvidence");

            migrationBuilder.DropTable(
                name: "FundingEligibilityDeclaration");
        }
    }
}
