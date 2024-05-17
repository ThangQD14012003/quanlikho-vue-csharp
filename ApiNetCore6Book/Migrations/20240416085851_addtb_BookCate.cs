using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNetCore6Book.Migrations
{
    /// <inheritdoc />
    public partial class addtb_BookCate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCategoryIdCate",
                table: "Bookk",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCate",
                table: "Bookk",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    IdCate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NXB = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => x.IdCate);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookk_BookCategoryIdCate",
                table: "Bookk",
                column: "BookCategoryIdCate");

            migrationBuilder.CreateIndex(
                name: "IX_Bookk_IdCate",
                table: "Bookk",
                column: "IdCate");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookk_BookCategory_BookCategoryIdCate",
                table: "Bookk",
                column: "BookCategoryIdCate",
                principalTable: "BookCategory",
                principalColumn: "IdCate");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookk_Bookk_IdCate",
                table: "Bookk",
                column: "IdCate",
                principalTable: "Bookk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookk_BookCategory_BookCategoryIdCate",
                table: "Bookk");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookk_Bookk_IdCate",
                table: "Bookk");

            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropIndex(
                name: "IX_Bookk_BookCategoryIdCate",
                table: "Bookk");

            migrationBuilder.DropIndex(
                name: "IX_Bookk_IdCate",
                table: "Bookk");

            migrationBuilder.DropColumn(
                name: "BookCategoryIdCate",
                table: "Bookk");

            migrationBuilder.DropColumn(
                name: "IdCate",
                table: "Bookk");
        }
    }
}
