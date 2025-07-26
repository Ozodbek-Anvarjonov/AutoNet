using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoftClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Country", "Description", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, "China", "Jetour is a brand under Chery Holding focusing on affordable SUVs.", "https://example.com/logos/jetour.png", "Jetour" },
                    { 2, "USA", "Chevrolet is one of America's most iconic automobile brands under General Motors.", "https://example.com/logos/chevrolet.png", "Chevrolet" },
                    { 3, "Germany", "BMW is a German multinational company producing luxury vehicles and motorcycles.", "https://example.com/logos/bmw.png", "BMW" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "Name", "Region" },
                values: new object[,]
                {
                    { 1, "Uzbekistan", "Jetour Salon", "Toshkent" },
                    { 2, "Uzbekistan", "GM Salon", "Namangan" },
                    { 3, "Uzbekistan", "BMW Salon", "Farg'ona" }
                });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "Phone", "Rating" },
                values: new object[,]
                {
                    { 1, "Toshkent sh., Chilonzor tumani", 1, "jetour@dealer.uz", "Jetour Dealer", "+998901234567", 4.5m },
                    { 2, "Namangan sh., Yangi shahar ko'chasi", 2, "gm@dealer.uz", "GM Uz Dealer", "+998911234567", 4.2m },
                    { 3, "Farg'ona sh., Mustaqillik ko'chasi", 3, "bmw@dealer.uz", "BMW Farg'ona", "+998931234567", 4.8m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dealers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
