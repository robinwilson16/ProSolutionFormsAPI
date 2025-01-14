using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class SwapCriminalConvictionstoBeOnetoManyOffences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "CriminalConviction");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "CriminalConviction");

            migrationBuilder.DropColumn(
                name: "Offence",
                table: "CriminalConviction");

            migrationBuilder.RenameColumn(
                name: "Penalty",
                table: "CriminalConviction",
                newName: "SignedStudent");

            migrationBuilder.RenameColumn(
                name: "DateOfOffence",
                table: "CriminalConviction",
                newName: "SignedStudentDate");

            migrationBuilder.AddColumn<bool>(
                name: "AgreeInfoIsCorrectStudent",
                table: "CriminalConviction",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CriminalConvictionOffenceModel",
                columns: table => new
                {
                    CriminalConvictionOffenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfOffence = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Offence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Penalty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriminalConvictionModelCriminalConvictionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriminalConvictionOffenceModel", x => x.CriminalConvictionOffenceID);
                    table.ForeignKey(
                        name: "FK_CriminalConvictionOffenceModel_CriminalConviction_CriminalConvictionModelCriminalConvictionID",
                        column: x => x.CriminalConvictionModelCriminalConvictionID,
                        principalTable: "CriminalConviction",
                        principalColumn: "CriminalConvictionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CriminalConvictionOffenceModel_CriminalConvictionModelCriminalConvictionID",
                table: "CriminalConvictionOffenceModel",
                column: "CriminalConvictionModelCriminalConvictionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriminalConvictionOffenceModel");

            migrationBuilder.DropColumn(
                name: "AgreeInfoIsCorrectStudent",
                table: "CriminalConviction");

            migrationBuilder.RenameColumn(
                name: "SignedStudentDate",
                table: "CriminalConviction",
                newName: "DateOfOffence");

            migrationBuilder.RenameColumn(
                name: "SignedStudent",
                table: "CriminalConviction",
                newName: "Penalty");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "CriminalConviction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "CriminalConviction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Offence",
                table: "CriminalConviction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
