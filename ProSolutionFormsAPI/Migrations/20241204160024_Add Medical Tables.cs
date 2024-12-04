using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicalTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalInformation",
                columns: table => new
                {
                    MedicalInformationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequiresRiskAssesment = table.Column<bool>(type: "bit", nullable: true),
                    HasBeenHospitalisedInLastYear = table.Column<bool>(type: "bit", nullable: true),
                    HospitalisationNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiresLearningSupport = table.Column<bool>(type: "bit", nullable: true),
                    HasEHCP = table.Column<bool>(type: "bit", nullable: true),
                    IsLAC = table.Column<bool>(type: "bit", nullable: true),
                    IsCareLeaver = table.Column<bool>(type: "bit", nullable: true),
                    HasFSM = table.Column<bool>(type: "bit", nullable: true),
                    IsFromMilitaryServiceFamily = table.Column<bool>(type: "bit", nullable: true),
                    HasAccessArrangements = table.Column<bool>(type: "bit", nullable: true),
                    AccessRequirementDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportInPlaceAtPriorSchoolOrCollege = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanContactPriorSchoolOrCollege = table.Column<bool>(type: "bit", nullable: true),
                    HasCriminalConvictions = table.Column<bool>(type: "bit", nullable: true),
                    CriminalConvictionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanShareInformationWithPotentialEmployers = table.Column<bool>(type: "bit", nullable: true),
                    AgreeInfoIsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    SignedStudent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignedStudentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignedParentCarer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignedParentCarerDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasGivenTripConsentStudent = table.Column<bool>(type: "bit", nullable: true),
                    HasGivenTripConsentParentCarer = table.Column<bool>(type: "bit", nullable: true),
                    HasGivenPhotographicImagesConsent = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentDetailID = table.Column<int>(type: "int", nullable: true),
                    AcademicYearID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    StudentRef = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalInformation", x => x.MedicalInformationID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalInformationDisabilityDifficulty",
                columns: table => new
                {
                    MedicalInformationDisabilityDifficultyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalInformationID = table.Column<int>(type: "int", nullable: true),
                    DisabilityID = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalInformationDisabilityDifficulty", x => x.MedicalInformationDisabilityDifficultyID);
                    table.ForeignKey(
                        name: "FK_MedicalInformationDisabilityDifficulty_MedicalInformation_MedicalInformationID",
                        column: x => x.MedicalInformationID,
                        principalTable: "MedicalInformation",
                        principalColumn: "MedicalInformationID");
                });

            migrationBuilder.CreateTable(
                name: "MedicalInformationEmergencyContact",
                columns: table => new
                {
                    MedicalInformationEmergencyContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalInformationID = table.Column<int>(type: "int", nullable: true),
                    ContactOrder = table.Column<int>(type: "int", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Forename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipToStudent = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCodeOut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCodeIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalInformationEmergencyContact", x => x.MedicalInformationEmergencyContactID);
                    table.ForeignKey(
                        name: "FK_MedicalInformationEmergencyContact_MedicalInformation_MedicalInformationID",
                        column: x => x.MedicalInformationID,
                        principalTable: "MedicalInformation",
                        principalColumn: "MedicalInformationID");
                });

            migrationBuilder.CreateTable(
                name: "MedicalInformationMedicalCondition",
                columns: table => new
                {
                    MedicalInformationMedicalConditionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalInformationID = table.Column<int>(type: "int", nullable: true),
                    MedicationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalInformationMedicalCondition", x => x.MedicalInformationMedicalConditionID);
                    table.ForeignKey(
                        name: "FK_MedicalInformationMedicalCondition_MedicalInformation_MedicalInformationID",
                        column: x => x.MedicalInformationID,
                        principalTable: "MedicalInformation",
                        principalColumn: "MedicalInformationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformationDisabilityDifficulty_MedicalInformationID",
                table: "MedicalInformationDisabilityDifficulty",
                column: "MedicalInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformationEmergencyContact_MedicalInformationID",
                table: "MedicalInformationEmergencyContact",
                column: "MedicalInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformationMedicalCondition_MedicalInformationID",
                table: "MedicalInformationMedicalCondition",
                column: "MedicalInformationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalInformationDisabilityDifficulty");

            migrationBuilder.DropTable(
                name: "MedicalInformationEmergencyContact");

            migrationBuilder.DropTable(
                name: "MedicalInformationMedicalCondition");

            migrationBuilder.DropTable(
                name: "MedicalInformation");
        }
    }
}
