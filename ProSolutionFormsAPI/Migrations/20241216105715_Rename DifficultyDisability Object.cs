using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameDifficultyDisabilityObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalInformationDisabilityDifficulty");

            migrationBuilder.AlterColumn<string>(
                name: "PostCodeOut",
                table: "MedicalInformationEmergencyContact",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostCodeIn",
                table: "MedicalInformationEmergencyContact",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasDifficultyDisability",
                table: "MedicalInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasMedicalCondition",
                table: "MedicalInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicalInformationDifficultyDisability",
                columns: table => new
                {
                    MedicalInformationDifficultyDisabilityID = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_MedicalInformationDifficultyDisability", x => x.MedicalInformationDifficultyDisabilityID);
                    table.ForeignKey(
                        name: "FK_MedicalInformationDifficultyDisability_MedicalInformation_MedicalInformationID",
                        column: x => x.MedicalInformationID,
                        principalTable: "MedicalInformation",
                        principalColumn: "MedicalInformationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformationDifficultyDisability_MedicalInformationID",
                table: "MedicalInformationDifficultyDisability",
                column: "MedicalInformationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalInformationDifficultyDisability");

            migrationBuilder.DropColumn(
                name: "HasDifficultyDisability",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "HasMedicalCondition",
                table: "MedicalInformation");

            migrationBuilder.AlterColumn<string>(
                name: "PostCodeOut",
                table: "MedicalInformationEmergencyContact",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostCodeIn",
                table: "MedicalInformationEmergencyContact",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MedicalInformationDisabilityDifficulty",
                columns: table => new
                {
                    MedicalInformationDisabilityDifficultyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalInformationID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisabilityID = table.Column<int>(type: "int", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformationDisabilityDifficulty_MedicalInformationID",
                table: "MedicalInformationDisabilityDifficulty",
                column: "MedicalInformationID");
        }
    }
}
