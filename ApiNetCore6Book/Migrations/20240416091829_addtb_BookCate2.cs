using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNetCore6Book.Migrations
{
    /// <inheritdoc />
    public partial class addtb_BookCate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookk_BookCategory_BookCategoryIdCate",
                table: "Bookk");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookk_Bookk_IdCate",
                table: "Bookk");

            migrationBuilder.DropIndex(
                name: "IX_Bookk_BookCategoryIdCate",
                table: "Bookk");

            migrationBuilder.DropColumn(
                name: "BookCategoryIdCate",
                table: "Bookk");

            migrationBuilder.DropColumn(
                name: "NXB",
                table: "BookCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookk_BookCategory_IdCate",
                table: "Bookk",
                column: "IdCate",
                principalTable: "BookCategory",
                principalColumn: "IdCate",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookk_BookCategory_IdCate",
                table: "Bookk");

            migrationBuilder.AddColumn<int>(
                name: "BookCategoryIdCate",
                table: "Bookk",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NXB",
                table: "BookCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bookk_BookCategoryIdCate",
                table: "Bookk",
                column: "BookCategoryIdCate");

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
    }
}
