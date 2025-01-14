using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameDifficultiestoLearningDifficulties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicalInformationDifficultyDisabilityID",
                table: "MedicalInformationDifficultyDisability",
                newName: "MedicalInformationLearningDifficultyDisabilityID");

            migrationBuilder.RenameColumn(
                name: "HasDifficultyDisability",
                table: "MedicalInformation",
                newName: "HasLearningDifficultyDisability");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicalInformationLearningDifficultyDisabilityID",
                table: "MedicalInformationDifficultyDisability",
                newName: "MedicalInformationDifficultyDisabilityID");

            migrationBuilder.RenameColumn(
                name: "HasLearningDifficultyDisability",
                table: "MedicalInformation",
                newName: "HasDifficultyDisability");
        }
    }
}
