using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFileSizeandNamefieldstoEvidenceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EvidenceContentType",
                table: "FundingEligibilityDeclarationEvidence",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvidenceFileName",
                table: "FundingEligibilityDeclarationEvidence",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EvidenceFileSize",
                table: "FundingEligibilityDeclarationEvidence",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvidenceContentType",
                table: "FundingEligibilityDeclarationEvidence");

            migrationBuilder.DropColumn(
                name: "EvidenceFileName",
                table: "FundingEligibilityDeclarationEvidence");

            migrationBuilder.DropColumn(
                name: "EvidenceFileSize",
                table: "FundingEligibilityDeclarationEvidence");
        }
    }
}
