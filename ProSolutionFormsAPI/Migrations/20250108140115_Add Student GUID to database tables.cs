using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentGUIDtodatabasetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentGUID",
                table: "MedicalLearningSupportAndTripConsent",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentGUID",
                table: "FundingEligibilityDeclaration",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentGUID",
                table: "CriminalConviction",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentGUID",
                table: "MedicalLearningSupportAndTripConsent");

            migrationBuilder.DropColumn(
                name: "StudentGUID",
                table: "FundingEligibilityDeclaration");

            migrationBuilder.DropColumn(
                name: "StudentGUID",
                table: "CriminalConviction");
        }
    }
}
