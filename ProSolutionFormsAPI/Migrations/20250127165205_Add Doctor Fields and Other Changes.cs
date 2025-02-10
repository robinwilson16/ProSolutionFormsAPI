using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorFieldsandOtherChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiresRiskAssesment",
                table: "MedicalLearningSupportAndTripConsent",
                newName: "AgreeToKeepCollegeInformed");

            migrationBuilder.RenameColumn(
                name: "AccessRequirementDetails",
                table: "MedicalLearningSupportAndTripConsent",
                newName: "NameOfDoctorsPractice");

            migrationBuilder.AddColumn<string>(
                name: "NameOfDoctor",
                table: "MedicalLearningSupportAndTripConsent",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfDoctor",
                table: "MedicalLearningSupportAndTripConsent");

            migrationBuilder.RenameColumn(
                name: "NameOfDoctorsPractice",
                table: "MedicalLearningSupportAndTripConsent",
                newName: "AccessRequirementDetails");

            migrationBuilder.RenameColumn(
                name: "AgreeToKeepCollegeInformed",
                table: "MedicalLearningSupportAndTripConsent",
                newName: "RequiresRiskAssesment");
        }
    }
}
