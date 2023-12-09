using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 9, 17, 41, 48, 295, DateTimeKind.Local).AddTicks(1213), "Jewelery, Jewelery & Clothing" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 9, 17, 41, 48, 295, DateTimeKind.Local).AddTicks(1299), "Tools, Automotive & Music" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 9, 17, 41, 48, 295, DateTimeKind.Local).AddTicks(1354), "Computers & Health" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 17, 41, 48, 323, DateTimeKind.Local).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 17, 41, 48, 323, DateTimeKind.Local).AddTicks(6262));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 17, 41, 48, 323, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 12, 9, 17, 41, 48, 323, DateTimeKind.Local).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 9, 17, 41, 48, 331, DateTimeKind.Local).AddTicks(1680), "Et veniam enim accusantium quia.", "Orta." });

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 9, 17, 41, 48, 331, DateTimeKind.Local).AddTicks(1803), "Çıktılar okuma sed ekşili velit.", "Olduğu doğru." });

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 9, 17, 41, 48, 331, DateTimeKind.Local).AddTicks(1904), "Mi architecto dışarı ut aliquam.", "Yaptı." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2023, 12, 9, 17, 41, 48, 340, DateTimeKind.Local).AddTicks(9125), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 6.224553081508144m, 159.41m, "Practical Granite Cheese" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2023, 12, 9, 17, 41, 48, 340, DateTimeKind.Local).AddTicks(9364), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 9.5934880401888904m, 295.86m, "Intelligent Frozen Ball" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 5, 11, 20, 51, 289, DateTimeKind.Local).AddTicks(6688), "Sports" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 5, 11, 20, 51, 289, DateTimeKind.Local).AddTicks(7225), "Garden & Home" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 12, 5, 11, 20, 51, 289, DateTimeKind.Local).AddTicks(7247), "Grocery & Tools" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 20, 51, 295, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 20, 51, 295, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 20, 51, 295, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 12, 5, 11, 20, 51, 295, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 5, 11, 20, 51, 297, DateTimeKind.Local).AddTicks(3495), "İçin sıfat sequi voluptatem consequuntur.", "Mutlu türemiş." });

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 5, 11, 20, 51, 297, DateTimeKind.Local).AddTicks(3529), "Aut çünkü dolorem velit ex.", "Qui makinesi." });

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 12, 5, 11, 20, 51, 297, DateTimeKind.Local).AddTicks(3608), "Dolor consequatur olduğu inventore quis.", "Kulu." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2023, 12, 5, 11, 20, 51, 298, DateTimeKind.Local).AddTicks(7460), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 9.142822675784496m, 599.98m, "Ergonomic Concrete Computer" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2023, 12, 5, 11, 20, 51, 298, DateTimeKind.Local).AddTicks(7488), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 5.086631753369008m, 329.59m, "Awesome Cotton Car" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
