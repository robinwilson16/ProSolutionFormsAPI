using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddnewfieldstoMedicalForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupportInPlaceAtPriorSchoolOrCollege",
                table: "MedicalLearningSupportAndTripConsent",
                newName: "FurtherSupportAtSchoolOrCollegeDetails");

            migrationBuilder.RenameColumn(
                name: "AgreeInfoIsCorrect",
                table: "MedicalLearningSupportAndTripConsent",
                newName: "IsYoungCarer");

            migrationBuilder.AddColumn<bool>(
                name: "AgreeInfoIsCorrectParentCarer",
                table: "MedicalLearningSupportAndTripConsent",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AgreeInfoIsCorrectStudent",
                table: "MedicalLearningSupportAndTripConsent",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HadFurtherSupportAtSchoolOrCollege",
                table: "MedicalLearningSupportAndTripConsent",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreeInfoIsCorrectParentCarer",
                table: "MedicalLearningSupportAndTripConsent");

            migrationBuilder.DropColumn(
                name: "AgreeInfoIsCorrectStudent",
                table: "MedicalLearningSupportAndTripConsent");

            migrationBuilder.DropColumn(
                name: "HadFurtherSupportAtSchoolOrCollege",
                table: "MedicalLearningSupportAndTripConsent");

            migrationBuilder.RenameColumn(
                name: "IsYoungCarer",
                table: "MedicalLearningSupportAndTripConsent",
                newName: "AgreeInfoIsCorrect");

            migrationBuilder.RenameColumn(
                name: "FurtherSupportAtSchoolOrCollegeDetails",
                table: "MedicalLearningSupportAndTripConsent",
                newName: "SupportInPlaceAtPriorSchoolOrCollege");
        }
    }
}
