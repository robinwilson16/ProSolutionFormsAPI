using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInterviewOutcometoInterviewHE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicantUnderstandsStructureOfCourse",
                table: "InterviewHE",
                newName: "UnderstandsStructureOfCourse");

            migrationBuilder.RenameColumn(
                name: "ApplicantIsAwareOfTuitionFee",
                table: "InterviewHE",
                newName: "IsAwareOfTuitionFee");

            migrationBuilder.AlterColumn<int>(
                name: "LastEducationalEstablishmentAttended",
                table: "InterviewHE",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewOutcome",
                table: "InterviewHE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastEducationalEstablishmentAttendedOtherDetail",
                table: "InterviewHE",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferingID",
                table: "InterviewHE",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterviewOutcome",
                table: "InterviewHE");

            migrationBuilder.DropColumn(
                name: "LastEducationalEstablishmentAttendedOtherDetail",
                table: "InterviewHE");

            migrationBuilder.DropColumn(
                name: "OfferingID",
                table: "InterviewHE");

            migrationBuilder.RenameColumn(
                name: "UnderstandsStructureOfCourse",
                table: "InterviewHE",
                newName: "ApplicantUnderstandsStructureOfCourse");

            migrationBuilder.RenameColumn(
                name: "IsAwareOfTuitionFee",
                table: "InterviewHE",
                newName: "ApplicantIsAwareOfTuitionFee");

            migrationBuilder.AlterColumn<string>(
                name: "LastEducationalEstablishmentAttended",
                table: "InterviewHE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
