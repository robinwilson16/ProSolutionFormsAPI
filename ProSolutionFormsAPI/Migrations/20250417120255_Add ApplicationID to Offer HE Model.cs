using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolutionFormsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationIDtoOfferHEModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "OfferHE",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "OfferHE");
        }
    }
}
