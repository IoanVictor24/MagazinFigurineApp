using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinFigurineApp.Migrations
{
    /// <inheritdoc />
    public partial class FinalFixForDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UtilizatorId",
                table: "Wishlisturi",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "DescriereDetaliata",
                table: "Figurine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PovestePersonaj",
                table: "Figurine",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriereDetaliata",
                table: "Figurine");

            migrationBuilder.DropColumn(
                name: "PovestePersonaj",
                table: "Figurine");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Wishlisturi",
                newName: "UtilizatorId");
        }
    }
}
