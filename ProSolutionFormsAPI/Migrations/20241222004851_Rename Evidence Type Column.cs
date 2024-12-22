using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameEvidenceTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EvidenceType",
                table: "FundingEligibilityDeclarationEvidence",
                newName: "EvidenceTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EvidenceTypeID",
                table: "FundingEligibilityDeclarationEvidence",
                newName: "EvidenceType");
        }
    }
}
