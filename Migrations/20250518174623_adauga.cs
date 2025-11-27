using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinFigurineApp.Migrations
{
    /// <inheritdoc />
    public partial class adauga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cosuri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FigurinaId = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosuri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cosuri_Figurine_FigurinaId",
                        column: x => x.FigurinaId,
                        principalTable: "Figurine",
                        principalColumn: "FigurinaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlisturi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FigurinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlisturi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlisturi_Figurine_FigurinaId",
                        column: x => x.FigurinaId,
                        principalTable: "Figurine",
                        principalColumn: "FigurinaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cosuri_FigurinaId",
                table: "Cosuri",
                column: "FigurinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlisturi_FigurinaId",
                table: "Wishlisturi",
                column: "FigurinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cosuri");

            migrationBuilder.DropTable(
                name: "Wishlisturi");
        }
    }
}
