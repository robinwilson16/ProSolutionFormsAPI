using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEvidencetoEvidenceContentinEvidenceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Evidence",
                table: "FundingEligibilityDeclarationEvidence",
                newName: "EvidenceContent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EvidenceContent",
                table: "FundingEligibilityDeclarationEvidence",
                newName: "Evidence");
        }
    }
}
