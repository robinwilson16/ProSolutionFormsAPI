using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameMedicalInformationID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformationDifficultyDisability_MedicalInformation_MedicalInformationID",
                table: "MedicalInformationDifficultyDisability");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformationEmergencyContact_MedicalInformation_MedicalInformationID",
                table: "MedicalInformationEmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformationMedicalCondition_MedicalInformation_MedicalInformationID",
                table: "MedicalInformationMedicalCondition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalInformationMedicalCondition",
                table: "MedicalInformationMedicalCondition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalInformationEmergencyContact",
                table: "MedicalInformationEmergencyContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalInformationDifficultyDisability",
                table: "MedicalInformationDifficultyDisability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalInformation",
                table: "MedicalInformation");

            migrationBuilder.RenameTable(
                name: "MedicalInformationMedicalCondition",
                newName: "MedicalLearningSupportAndTripConsentMedicalCondition");

            migrationBuilder.RenameTable(
                name: "MedicalInformationEmergencyContact",
                newName: "MedicalLearningSupportAndTripConsentEmergencyContact");

            migrationBuilder.RenameTable(
                name: "MedicalInformationDifficultyDisability",
                newName: "MedicalLearningSupportAndTripConsentLearningDifficultyDisability");

            migrationBuilder.RenameTable(
                name: "MedicalInformation",
                newName: "MedicalLearningSupportAndTripConsent");

            migrationBuilder.RenameColumn(
                name: "MedicalInformationID",
                table: "MedicalLearningSupportAndTripConsentMedicalCondition",
                newName: "MedicalLearningSupportAndTripConsentID");

            migrationBuilder.RenameColumn(
                name: "MedicalInformationMedicalConditionID",
                table: "MedicalLearningSupportAndTripConsentMedicalCondition",
                newName: "MedicalLearningSupportAndTripConsentMedicalConditionID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalInformationMedicalCondition_MedicalInformationID",
                table: "MedicalLearningSupportAndTripConsentMedicalCondition",
                newName: "IX_MedicalLearningSupportAndTripConsentMedicalCondition_MedicalLearningSupportAndTripConsentID");

            migrationBuilder.RenameColumn(
                name: "MedicalInformationID",
                table: "MedicalLearningSupportAndTripConsentEmergencyContact",
                newName: "MedicalLearningSupportAndTripConsentID");

            migrationBuilder.RenameColumn(
                name: "MedicalInformationEmergencyContactID",
                table: "MedicalLearningSupportAndTripConsentEmergencyContact",
                newName: "MedicalLearningSupportAndTripConsentEmergencyContactID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalInformationEmergencyContact_MedicalInformationID",
                table: "MedicalLearningSupportAndTripConsentEmergencyContact",
                newName: "IX_MedicalLearningSupportAndTripConsentEmergencyContact_MedicalLearningSupportAndTripConsentID");

            migrationBuilder.RenameColumn(
                name: "MedicalInformationID",
                table: "MedicalLearningSupportAndTripConsentLearningDifficultyDisability",
                newName: "MedicalLearningSupportAndTripConsentID");

            migrationBuilder.RenameColumn(
                name: "MedicalInformationLearningDifficultyDisabilityID",
                table: "MedicalLearningSupportAndTripConsentLearningDifficultyDisability",
                newName: "MedicalLearningSupportAndTripConsentLearningDifficultyDisabilityID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalInformationDifficultyDisability_MedicalInformationID",
                table: "MedicalLearningSupportAndTripConsentLearningDifficultyDisability",
                newName: "IX_MedicalLearningSupportAndTripConsentLearningDifficultyDisability_MedicalLearningSupportAndTripConsentID");

            migrationBuilder.RenameColumn(
                name: "MedicalInformationID",
                table: "MedicalLearningSupportAndTripConsent",
                newName: "MedicalLearningSupportAndTripConsentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalLearningSupportAndTripConsentMedicalCondition",
                table: "MedicalLearningSupportAndTripConsentMedicalCondition",
                column: "MedicalLearningSupportAndTripConsentMedicalConditionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalLearningSupportAndTripConsentEmergencyContact",
                table: "MedicalLearningSupportAndTripConsentEmergencyContact",
                column: "MedicalLearningSupportAndTripConsentEmergencyContactID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalLearningSupportAndTripConsentLearningDifficultyDisability",
                table: "MedicalLearningSupportAndTripConsentLearningDifficultyDisability",
                column: "MedicalLearningSupportAndTripConsentLearningDifficultyDisabilityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalLearningSupportAndTripConsent",
                table: "MedicalLearningSupportAndTripConsent",
                column: "MedicalLearningSupportAndTripConsentID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalLearningSupportAndTripConsentEmergencyContact_MedicalLearningSupportAndTripConsent_MedicalLearningSupportAndTripConse~",
                table: "MedicalLearningSupportAndTripConsentEmergencyContact",
                column: "MedicalLearningSupportAndTripConsentID",
                principalTable: "MedicalLearningSupportAndTripConsent",
                principalColumn: "MedicalLearningSupportAndTripConsentID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalLearningSupportAndTripConsentLearningDifficultyDisability_MedicalLearningSupportAndTripConsent_MedicalLearningSupport~",
                table: "MedicalLearningSupportAndTripConsentLearningDifficultyDisability",
                column: "MedicalLearningSupportAndTripConsentID",
                principalTable: "MedicalLearningSupportAndTripConsent",
                principalColumn: "MedicalLearningSupportAndTripConsentID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalLearningSupportAndTripConsentMedicalCondition_MedicalLearningSupportAndTripConsent_MedicalLearningSupportAndTripConse~",
                table: "MedicalLearningSupportAndTripConsentMedicalCondition",
                column: "MedicalLearningSupportAndTripConsentID",
                principalTable: "MedicalLearningSupportAndTripConsent",
                principalColumn: "MedicalLearningSupportAndTripConsentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalLearningSupportAndTripConsentEmergencyContact_MedicalLearningSupportAndTripConsent_MedicalLearningSupportAndTripConse~",
                table: "MedicalLearningSupportAndTripConsentEmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalLearningSupportAndTripConsentLearningDifficultyDisability_MedicalLearningSupportAndTripConsent_MedicalLearningSupport~",
                table: "MedicalLearningSupportAndTripConsentLearningDifficultyDisability");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalLearningSupportAndTripConsentMedicalCondition_MedicalLearningSupportAndTripConsent_MedicalLearningSupportAndTripConse~",
                table: "MedicalLearningSupportAndTripConsentMedicalCondition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalLearningSupportAndTripConsentMedicalCondition",
                table: "MedicalLearningSupportAndTripConsentMedicalCondition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalLearningSupportAndTripConsentLearningDifficultyDisability",
                table: "MedicalLearningSupportAndTripConsentLearningDifficultyDisability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalLearningSupportAndTripConsentEmergencyContact",
                table: "MedicalLearningSupportAndTripConsentEmergencyContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalLearningSupportAndTripConsent",
                table: "MedicalLearningSupportAndTripConsent");

            migrationBuilder.RenameTable(
                name: "MedicalLearningSupportAndTripConsentMedicalCondition",
                newName: "MedicalInformationMedicalCondition");

            migrationBuilder.RenameTable(
                name: "MedicalLearningSupportAndTripConsentLearningDifficultyDisability",
                newName: "MedicalInformationDifficultyDisability");

            migrationBuilder.RenameTable(
                name: "MedicalLearningSupportAndTripConsentEmergencyContact",
                newName: "MedicalInformationEmergencyContact");

            migrationBuilder.RenameTable(
                name: "MedicalLearningSupportAndTripConsent",
                newName: "MedicalInformation");

            migrationBuilder.RenameColumn(
                name: "MedicalLearningSupportAndTripConsentID",
                table: "MedicalInformationMedicalCondition",
                newName: "MedicalInformationID");

            migrationBuilder.RenameColumn(
                name: "MedicalLearningSupportAndTripConsentMedicalConditionID",
                table: "MedicalInformationMedicalCondition",
                newName: "MedicalInformationMedicalConditionID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalLearningSupportAndTripConsentMedicalCondition_MedicalLearningSupportAndTripConsentID",
                table: "MedicalInformationMedicalCondition",
                newName: "IX_MedicalInformationMedicalCondition_MedicalInformationID");

            migrationBuilder.RenameColumn(
                name: "MedicalLearningSupportAndTripConsentID",
                table: "MedicalInformationDifficultyDisability",
                newName: "MedicalInformationID");

            migrationBuilder.RenameColumn(
                name: "MedicalLearningSupportAndTripConsentLearningDifficultyDisabilityID",
                table: "MedicalInformationDifficultyDisability",
                newName: "MedicalInformationLearningDifficultyDisabilityID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalLearningSupportAndTripConsentLearningDifficultyDisability_MedicalLearningSupportAndTripConsentID",
                table: "MedicalInformationDifficultyDisability",
                newName: "IX_MedicalInformationDifficultyDisability_MedicalInformationID");

            migrationBuilder.RenameColumn(
                name: "MedicalLearningSupportAndTripConsentID",
                table: "MedicalInformationEmergencyContact",
                newName: "MedicalInformationID");

            migrationBuilder.RenameColumn(
                name: "MedicalLearningSupportAndTripConsentEmergencyContactID",
                table: "MedicalInformationEmergencyContact",
                newName: "MedicalInformationEmergencyContactID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalLearningSupportAndTripConsentEmergencyContact_MedicalLearningSupportAndTripConsentID",
                table: "MedicalInformationEmergencyContact",
                newName: "IX_MedicalInformationEmergencyContact_MedicalInformationID");

            migrationBuilder.RenameColumn(
                name: "MedicalLearningSupportAndTripConsentID",
                table: "MedicalInformation",
                newName: "MedicalInformationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalInformationMedicalCondition",
                table: "MedicalInformationMedicalCondition",
                column: "MedicalInformationMedicalConditionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalInformationDifficultyDisability",
                table: "MedicalInformationDifficultyDisability",
                column: "MedicalInformationLearningDifficultyDisabilityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalInformationEmergencyContact",
                table: "MedicalInformationEmergencyContact",
                column: "MedicalInformationEmergencyContactID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalInformation",
                table: "MedicalInformation",
                column: "MedicalInformationID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformationDifficultyDisability_MedicalInformation_MedicalInformationID",
                table: "MedicalInformationDifficultyDisability",
                column: "MedicalInformationID",
                principalTable: "MedicalInformation",
                principalColumn: "MedicalInformationID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformationEmergencyContact_MedicalInformation_MedicalInformationID",
                table: "MedicalInformationEmergencyContact",
                column: "MedicalInformationID",
                principalTable: "MedicalInformation",
                principalColumn: "MedicalInformationID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformationMedicalCondition_MedicalInformation_MedicalInformationID",
                table: "MedicalInformationMedicalCondition",
                column: "MedicalInformationID",
                principalTable: "MedicalInformation",
                principalColumn: "MedicalInformationID");
        }
    }
}
