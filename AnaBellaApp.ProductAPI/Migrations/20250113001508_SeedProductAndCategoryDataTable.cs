using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnaBellaApp.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductAndCategoryDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1L, "Bermudas em geral", "Bermudas" },
                    { 2L, "Camisetas e blusas em geral", "Camisetas e Blusas" }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_id", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 1L, 1L, "Bermuda linho com elastano. Tamanho 40 ao 48", "https://github.com/trodrigo/AnaBellaApp/blob/master/AnaBellaImages/bermuda_linho_elastano.jpg", "Bermuda linho", 69.9m },
                    { 2L, 2L, "Blusa canelada com manga tamanho único regular", "https://github.com/trodrigo/AnaBellaApp/blob/master/AnaBellaImages/blusa_canelada.jpg", "Blusa canelada", 69.9m },
                    { 3L, 2L, "Regata canelada com manga tamanho único regular", "https://github.com/trodrigo/AnaBellaApp/blob/master/AnaBellaImages/regata_canelada.jpg", "Regata canelada", 69.9m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 2L);
        }
    }
}
