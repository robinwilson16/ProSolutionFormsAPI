using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseCodetoCriminalConvictionTableandFundingInformationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "FundingEligibilityDeclaration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "CriminalConviction",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "FundingEligibilityDeclaration");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "CriminalConviction");
        }
    }
}
