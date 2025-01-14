using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameOffenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriminalConvictionOffenceModel_CriminalConviction_CriminalConvictionModelCriminalConvictionID",
                table: "CriminalConvictionOffenceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriminalConvictionOffenceModel",
                table: "CriminalConvictionOffenceModel");

            migrationBuilder.RenameTable(
                name: "CriminalConvictionOffenceModel",
                newName: "CriminalConvictionOffence");

            migrationBuilder.RenameIndex(
                name: "IX_CriminalConvictionOffenceModel_CriminalConvictionModelCriminalConvictionID",
                table: "CriminalConvictionOffence",
                newName: "IX_CriminalConvictionOffence_CriminalConvictionModelCriminalConvictionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriminalConvictionOffence",
                table: "CriminalConvictionOffence",
                column: "CriminalConvictionOffenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_CriminalConvictionOffence_CriminalConviction_CriminalConvictionModelCriminalConvictionID",
                table: "CriminalConvictionOffence",
                column: "CriminalConvictionModelCriminalConvictionID",
                principalTable: "CriminalConviction",
                principalColumn: "CriminalConvictionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriminalConvictionOffence_CriminalConviction_CriminalConvictionModelCriminalConvictionID",
                table: "CriminalConvictionOffence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriminalConvictionOffence",
                table: "CriminalConvictionOffence");

            migrationBuilder.RenameTable(
                name: "CriminalConvictionOffence",
                newName: "CriminalConvictionOffenceModel");

            migrationBuilder.RenameIndex(
                name: "IX_CriminalConvictionOffence_CriminalConvictionModelCriminalConvictionID",
                table: "CriminalConvictionOffenceModel",
                newName: "IX_CriminalConvictionOffenceModel_CriminalConvictionModelCriminalConvictionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriminalConvictionOffenceModel",
                table: "CriminalConvictionOffenceModel",
                column: "CriminalConvictionOffenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_CriminalConvictionOffenceModel_CriminalConviction_CriminalConvictionModelCriminalConvictionID",
                table: "CriminalConvictionOffenceModel",
                column: "CriminalConvictionModelCriminalConvictionID",
                principalTable: "CriminalConviction",
                principalColumn: "CriminalConvictionID");
        }
    }
}
