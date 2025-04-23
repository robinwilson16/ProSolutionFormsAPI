using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInterviewFormHEDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewHE",
                columns: table => new
                {
                    InterviewHEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivationForStudyingCourseAndIntendedNextSteps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuitabilityAndRelevantQualificationsAndExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighestQualOnEntryLevel = table.Column<int>(type: "int", nullable: true),
                    HighestQualOnEntryDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasDifficultiesAndOrDisabilities = table.Column<bool>(type: "bit", nullable: true),
                    DifficultiesAndOrDisabilitiesFurtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantUnderstandsStructureOfCourse = table.Column<bool>(type: "bit", nullable: true),
                    MethodOfFunding = table.Column<int>(type: "int", nullable: true),
                    ApplicantIsAwareOfTuitionFee = table.Column<bool>(type: "bit", nullable: true),
                    TuitionFeeAgreedTo = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    InEmployment = table.Column<bool>(type: "bit", nullable: true),
                    LastEducationalEstablishmentAttended = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinanciallySupportSelfDuringCourse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManageDemandsOfStudyAroundJobAndFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeardAboutCourse = table.Column<int>(type: "int", nullable: true),
                    HeardAboutCourseOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionsAskedAndAdviceGiven = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentDetailID = table.Column<int>(type: "int", nullable: true),
                    AcademicYearID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    StudentRef = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    StudentGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewHE", x => x.InterviewHEID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewHE");
        }
    }
}
