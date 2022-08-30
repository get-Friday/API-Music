using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Music.Data.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "Alias", "CountryFrom", "Name", "PhotoUrl" },
                values: new object[] { 1, "Eminem", "United States of America", "Marshall Bruce Mathers III", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Eminem_-_Concert_for_Valor_in_Washington%2C_D.C._Nov._11%2C_2014_%282%29_%28Cropped%29.jpg/220px-Eminem_-_Concert_for_Valor_in_Washington%2C_D.C._Nov._11%2C_2014_%282%29_%28Cropped%29.jpg" });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "Alias", "CountryFrom", "Name", "PhotoUrl" },
                values: new object[] { 2, "Snoop Dogg", "United States of America", "Calvin Cordozar Broadus Jr.", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/17/Snoop_Dogg_2019_by_Glenn_Francis.jpg/220px-Snoop_Dogg_2019_by_Glenn_Francis.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
