using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinFigurineApp.Migrations
{
    /// <inheritdoc />
    public partial class AddImagineUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagineUrl",
                table: "Figurine",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagineUrl",
                table: "Figurine");
        }
    }
}
