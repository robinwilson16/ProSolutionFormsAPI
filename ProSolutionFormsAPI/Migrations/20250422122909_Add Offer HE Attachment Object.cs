using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddOfferHEAttachmentObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationOfIdentity",
                table: "OfferHE");

            migrationBuilder.RenameColumn(
                name: "TermTimeAccomodation",
                table: "OfferHE",
                newName: "TermTimeAccomodationID");

            migrationBuilder.RenameColumn(
                name: "SponsorTel",
                table: "OfferHE",
                newName: "EmployerTel");

            migrationBuilder.RenameColumn(
                name: "SponsorPostCode",
                table: "OfferHE",
                newName: "EmployerPostCode");

            migrationBuilder.RenameColumn(
                name: "SponsorName",
                table: "OfferHE",
                newName: "EmployerName");

            migrationBuilder.RenameColumn(
                name: "SponsorEmail",
                table: "OfferHE",
                newName: "EmployerEmail");

            migrationBuilder.RenameColumn(
                name: "SponsorAddress3",
                table: "OfferHE",
                newName: "EmployerAddress3");

            migrationBuilder.RenameColumn(
                name: "SponsorAddress2",
                table: "OfferHE",
                newName: "EmployerAddress2");

            migrationBuilder.RenameColumn(
                name: "SponsorAddress1",
                table: "OfferHE",
                newName: "EmployerAddress1");

            migrationBuilder.RenameColumn(
                name: "MethodOfFunding",
                table: "OfferHE",
                newName: "MethodOfFundingID");

            migrationBuilder.RenameColumn(
                name: "LastEducationalEstablishmentAttendedOffer",
                table: "OfferHE",
                newName: "LastEducationalEstablishmentAttendedOfferID");

            migrationBuilder.RenameColumn(
                name: "HighestQualOnEntryLevel",
                table: "OfferHE",
                newName: "HighestQualOnEntryLevelID");

            migrationBuilder.CreateTable(
                name: "OfferHEAttachmentModel",
                columns: table => new
                {
                    OfferHEAttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferHEID = table.Column<int>(type: "int", nullable: true),
                    AttachmentTypeID = table.Column<int>(type: "int", nullable: false),
                    AttachmentContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageThumbnail = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AttachmentFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentFileSize = table.Column<long>(type: "bigint", nullable: true),
                    AttachmentFileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferHEAttachmentModel", x => x.OfferHEAttachmentID);
                    table.ForeignKey(
                        name: "FK_OfferHEAttachmentModel_OfferHE_OfferHEID",
                        column: x => x.OfferHEID,
                        principalTable: "OfferHE",
                        principalColumn: "OfferHEID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferHEAttachmentModel_OfferHEID",
                table: "OfferHEAttachmentModel",
                column: "OfferHEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferHEAttachmentModel");

            migrationBuilder.RenameColumn(
                name: "TermTimeAccomodationID",
                table: "OfferHE",
                newName: "TermTimeAccomodation");

            migrationBuilder.RenameColumn(
                name: "MethodOfFundingID",
                table: "OfferHE",
                newName: "MethodOfFunding");

            migrationBuilder.RenameColumn(
                name: "LastEducationalEstablishmentAttendedOfferID",
                table: "OfferHE",
                newName: "LastEducationalEstablishmentAttendedOffer");

            migrationBuilder.RenameColumn(
                name: "HighestQualOnEntryLevelID",
                table: "OfferHE",
                newName: "HighestQualOnEntryLevel");

            migrationBuilder.RenameColumn(
                name: "EmployerTel",
                table: "OfferHE",
                newName: "SponsorTel");

            migrationBuilder.RenameColumn(
                name: "EmployerPostCode",
                table: "OfferHE",
                newName: "SponsorPostCode");

            migrationBuilder.RenameColumn(
                name: "EmployerName",
                table: "OfferHE",
                newName: "SponsorName");

            migrationBuilder.RenameColumn(
                name: "EmployerEmail",
                table: "OfferHE",
                newName: "SponsorEmail");

            migrationBuilder.RenameColumn(
                name: "EmployerAddress3",
                table: "OfferHE",
                newName: "SponsorAddress3");

            migrationBuilder.RenameColumn(
                name: "EmployerAddress2",
                table: "OfferHE",
                newName: "SponsorAddress2");

            migrationBuilder.RenameColumn(
                name: "EmployerAddress1",
                table: "OfferHE",
                newName: "SponsorAddress1");

            migrationBuilder.AddColumn<int>(
                name: "ConfirmationOfIdentity",
                table: "OfferHE",
                type: "int",
                nullable: true);
        }
    }
}
