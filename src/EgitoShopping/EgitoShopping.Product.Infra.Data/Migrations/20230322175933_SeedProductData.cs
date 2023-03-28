using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgitoShopping.Product.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Produtos",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoryName", "description", "name", "price", "url_image" },
                values: new object[] { 3L, "Presentes", "Capacete tamanho real Darth Vader - Star Wars", "Capacete Darth Vader", 255.5m, "C:\\Users\\emmanuel.marinho\\Downloads\\ShoppingImages\\3_vader" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.AlterColumn<string>(
                name: "price",
                table: "Produtos",
                type: "nvarchar(max)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
