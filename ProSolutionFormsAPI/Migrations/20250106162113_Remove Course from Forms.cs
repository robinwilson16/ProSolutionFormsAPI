using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCoursefromForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "MedicalLearningSupportAndTripConsent");

            migrationBuilder.DropColumn(
                name: "OfferingID",
                table: "MedicalLearningSupportAndTripConsent");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "FundingEligibilityDeclaration");

            migrationBuilder.DropColumn(
                name: "OfferingID",
                table: "FundingEligibilityDeclaration");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "CriminalConviction");

            migrationBuilder.DropColumn(
                name: "OfferingID",
                table: "CriminalConviction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "MedicalLearningSupportAndTripConsent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferingID",
                table: "MedicalLearningSupportAndTripConsent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "FundingEligibilityDeclaration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferingID",
                table: "FundingEligibilityDeclaration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "CriminalConviction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferingID",
                table: "CriminalConviction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
