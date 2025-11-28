using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCRUD.Migrations
{
    /// <inheritdoc />
    public partial class updateCatname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryCategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CaregoryName",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategory",
                table: "Products",
                column: "ProductCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_ProductCategory",
                table: "Products",
                column: "ProductCategory",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_ProductCategory",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategory",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "CaregoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCategoryId",
                table: "Products",
                column: "CategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryCategoryId",
                table: "Products",
                column: "CategoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }
    }
}
