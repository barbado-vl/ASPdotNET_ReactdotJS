using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASPdotNET_ReactdotJS.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ranking = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ItemsModel",
                columns: new[] { "Id", "ImageId", "ItemType", "Ranking", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, "The Godfather" },
                    { 2, 2, 1, 0, "Highlander" },
                    { 3, 3, 1, 0, "Highlander II" },
                    { 4, 4, 1, 0, "The Last of the Mohicans" },
                    { 5, 5, 1, 0, "Police Academy 6" },
                    { 6, 6, 1, 0, "Rear Window" },
                    { 7, 7, 1, 0, "Road House" },
                    { 8, 8, 1, 0, "The Shawshank Redemption" },
                    { 9, 9, 1, 0, "Star Treck IV" },
                    { 10, 10, 1, 0, "Superman 4" },
                    { 11, 11, 2, 0, "Abbey Road" },
                    { 12, 12, 2, 0, "Adrenalize" },
                    { 13, 13, 2, 0, "Back in Black" },
                    { 14, 14, 2, 0, "Enjoy the Silence" },
                    { 15, 15, 2, 0, "Parachutes" },
                    { 16, 16, 2, 0, "Ride the Lightning" },
                    { 17, 17, 2, 0, "Rock or Bust" },
                    { 18, 18, 2, 0, "Rust in Peace" },
                    { 19, 19, 2, 0, "St. Anger" },
                    { 20, 20, 2, 0, "The Final Countdown" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsModel");
        }
    }
}
