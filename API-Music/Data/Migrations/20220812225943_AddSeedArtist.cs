using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Music.Data.Migrations
{
    public partial class AddSeedArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "Alias", "CountryFrom", "Name", "PhotoUrl" },
                values: new object[] { 1, "Slim shady", "United States of America", "Eminem", "https://en.wikipedia.org/wiki/File:Eminem_-_Concert_for_Valor_in_Washington,_D.C._Nov._11,_2014_(2)_(Cropped).jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
