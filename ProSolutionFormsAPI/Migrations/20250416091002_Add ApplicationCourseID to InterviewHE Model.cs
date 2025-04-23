using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationCourseIDtoInterviewHEModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationCourseID",
                table: "InterviewHE",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationCourseID",
                table: "InterviewHE");
        }
    }
}
