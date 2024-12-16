using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameDisabilityIDfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisabilityID",
                table: "MedicalInformationDifficultyDisability",
                newName: "DisabilityCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisabilityCategoryID",
                table: "MedicalInformationDifficultyDisability",
                newName: "DisabilityID");
        }
    }
}
