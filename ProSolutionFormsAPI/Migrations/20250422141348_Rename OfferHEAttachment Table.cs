using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameOfferHEAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferHEAttachmentModel_OfferHE_OfferHEID",
                table: "OfferHEAttachmentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferHEAttachmentModel",
                table: "OfferHEAttachmentModel");

            migrationBuilder.RenameTable(
                name: "OfferHEAttachmentModel",
                newName: "OfferHEAttachment");

            migrationBuilder.RenameIndex(
                name: "IX_OfferHEAttachmentModel_OfferHEID",
                table: "OfferHEAttachment",
                newName: "IX_OfferHEAttachment_OfferHEID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferHEAttachment",
                table: "OfferHEAttachment",
                column: "OfferHEAttachmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferHEAttachment_OfferHE_OfferHEID",
                table: "OfferHEAttachment",
                column: "OfferHEID",
                principalTable: "OfferHE",
                principalColumn: "OfferHEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferHEAttachment_OfferHE_OfferHEID",
                table: "OfferHEAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferHEAttachment",
                table: "OfferHEAttachment");

            migrationBuilder.RenameTable(
                name: "OfferHEAttachment",
                newName: "OfferHEAttachmentModel");

            migrationBuilder.RenameIndex(
                name: "IX_OfferHEAttachment_OfferHEID",
                table: "OfferHEAttachmentModel",
                newName: "IX_OfferHEAttachmentModel_OfferHEID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferHEAttachmentModel",
                table: "OfferHEAttachmentModel",
                column: "OfferHEAttachmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferHEAttachmentModel_OfferHE_OfferHEID",
                table: "OfferHEAttachmentModel",
                column: "OfferHEID",
                principalTable: "OfferHE",
                principalColumn: "OfferHEID");
        }
    }
}
