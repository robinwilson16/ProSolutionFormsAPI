using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueReferenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentUniqueReference",
                columns: table => new
                {
                    StudentUniqueReferenceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentRef = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUniqueReference", x => x.StudentUniqueReferenceID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentUniqueReference_StudentRef",
                table: "StudentUniqueReference",
                column: "StudentRef",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentUniqueReference");
        }
    }
}
