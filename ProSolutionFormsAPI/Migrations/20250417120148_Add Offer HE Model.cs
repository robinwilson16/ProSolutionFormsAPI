using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddOfferHEModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferHE",
                columns: table => new
                {
                    OfferHEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuitionFee = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    MethodOfFunding = table.Column<int>(type: "int", nullable: true),
                    SponsorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorAddress3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorPostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UCASNumber = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermTimeAccomodation = table.Column<int>(type: "int", nullable: true),
                    TermTimeAccomodationOtherDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighestQualOnEntryLevel = table.Column<int>(type: "int", nullable: true),
                    LastEducationalEstablishmentAttendedOffer = table.Column<int>(type: "int", nullable: true),
                    ConfirmationOfIdentity = table.Column<int>(type: "int", nullable: true),
                    ConfirmInformationAndAttachmentsAreAccurate = table.Column<bool>(type: "bit", nullable: true),
                    HaveReadHEOfferTermsAndConditions = table.Column<bool>(type: "bit", nullable: true),
                    UnderstandTermsAndConditionsBasedOnFundingMethodSpecified = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentDetailID = table.Column<int>(type: "int", nullable: true),
                    AcademicYearID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    StudentRef = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    StudentGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OfferingID = table.Column<int>(type: "int", nullable: true),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationCourseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferHE", x => x.OfferHEID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferHE");
        }
    }
}
