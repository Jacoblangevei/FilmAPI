using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmAPI.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Characters_CharacterId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharacterId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Characters");

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharactersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUrl",
                value: "https://static.wikia.nocookie.net/lotr/images/3/32/Frodo_%28FotR%29.png/revision/latest?cb=20221006065757");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2,
                column: "PictureUrl",
                value: "https://static.wikia.nocookie.net/warner-bros-entertainment/images/6/6a/94E54497-FAC0-4332-9531-27A0A5962043.jpeg/revision/latest?cb=20190108035325");

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "PictureUrl" },
                values: new object[,]
                {
                    { 3, "Gollum", "Sméagol", "Male", "https://pyxis.nymag.com/v1/imgs/5d4/f6e/c6aeaba039ba41d69a9dbce8c3523ec471-11-gollum.rsquare.w700.jpg" },
                    { 4, "The Chosen One", "Luke Skywalker", "Male", "https://static.wikia.nocookie.net/starwars/images/2/20/LukeTLJ.jpg/revision/latest?cb=20170927045449" },
                    { 5, "Ben Kenobi", "Obi-Wan Kenobi", "Male", "https://static.wikia.nocookie.net/starwars/images/4/4e/ObiWanHS-SWE.jpg/revision/latest?cb=20111126060943" },
                    { 6, "Darth Vader", "Anakin Skywalker", "Male", "https://imageio.forbes.com/specials-images/imageserve/6090f7f251c9c6c605e612fc/Darth-Vader/0x0.jpg?format=jpg&crop=3127,1759,x0,y33,safe&width=960" },
                    { 7, "The Boy Who Lived", "Harry James Potter", "Male", "https://static.wikia.nocookie.net/harrypotter/images/0/0e/Harry_James_Potter.jpg/revision/latest?cb=20150808063507" },
                    { 8, "Lord Voldemort", "Tom Marvolo Riddle", "Male", "https://static.wikia.nocookie.net/harrypotter/images/4/4b/VoldemortHeadshot_DHP1.png/revision/latest?cb=20161223175148" },
                    { 9, "Professor Dumbledore", "Albus Percival Wulfric Brian Dumbledore", "Male", "https://static.wikia.nocookie.net/harrypotter/images/5/5e/Albus_Dumbledore_%28HBP_promo%29_2.jpg/revision/latest?cb=20150808063507" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "The fantasy franchise based on J.K. Rowling's novels.", "Harry Potter" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUrl",
                value: "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PictureUrl", "ReleaseYear", "TrailerUrl" },
                values: new object[] { "https://m.media-amazon.com/images/M/MV5BZGMxZTdjZmYtMmE2Ni00ZTdkLWI5NTgtNjlmMjBiNzU2MmI5XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_FMjpg_UX1000_.jpg", 2002, "https://www.youtube.com/watch?v=hYcw5ksV8YQ" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "PictureUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 3, "Peter Jackson", 1, "Epic fantasy", "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", 2003, "The Return of the King", "https://www.youtube.com/watch?v=r5X-hFf6Bwo" },
                    { 4, "George Lucas", 2, "Space opera", "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg", 1977, "Star Wars Episode IV: A New Hope", "https://www.youtube.com/watch?v=1g3_CFmnU7k" },
                    { 5, "Irvin Kershner", 2, "Space opera", "https://upload.wikimedia.org/wikipedia/en/3/3c/SW_-_Empire_Strikes_Back.jpg", 1980, "Star Wars Episode V: The Empire Strikes Back", "https://www.youtube.com/watch?v=JNwNXF9Y6kY" },
                    { 6, "Richard Marquand", 2, "Space opera", "https://upload.wikimedia.org/wikipedia/en/b/b2/ReturnOfTheJediPoster1983.jpg", 1983, "Star Wars Episode VI: Return of the Jedi", "https://www.youtube.com/watch?v=7L8p7_SLzvU" },
                    { 7, "Chris Columbus", 3, "Fantasy", "https://upload.wikimedia.org/wikipedia/en/b/bf/Harry_Potter_and_the_Philosopher%27s_Stone_posters.JPG", 2001, "Harry Potter and the Philosopher's Stone", "https://www.youtube.com/watch?v=VyHV0BRtdxo" },
                    { 8, "Chris Columbus", 3, "Fantasy", "https://upload.wikimedia.org/wikipedia/en/c/c0/Harry_Potter_and_the_Chamber_of_Secrets_movie.jpg", 2002, "Harry Potter and the Chamber of Secrets", "https://www.youtube.com/watch?v=1bq0qff4iF8" },
                    { 9, "Alfonso Cuarón", 3, "Fantasy", "https://upload.wikimedia.org/wikipedia/en/b/bc/Prisoner_of_azkaban_UK_poster.jpg", 2004, "Harry Potter and the Prisoner of Azkaban", "https://www.youtube.com/watch?v=lAxgztbYDbs" },
                    { 10, "Mike Newell", 3, "Fantasy", "https://upload.wikimedia.org/wikipedia/en/c/c9/Harry_Potter_and_the_Goblet_of_Fire_Poster.jpg", 2005, "Harry Potter and the Goblet of Fire", "https://www.youtube.com/watch?v=PFWAOnvMd1Q" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MoviesId",
                table: "CharacterMovie",
                column: "MoviesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CharacterId", "PictureUrl" },
                values: new object[] { null, "https://example.com/frodo.jpg" });

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CharacterId", "PictureUrl" },
                values: new object[] { null, "https://example.com/aragorn.jpg" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/thumb/a/a1/The_Two_Towers_cover.gif/220px-The_Two_Towers_cover.gif");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PictureUrl", "ReleaseYear", "TrailerUrl" },
                values: new object[] { "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_.jpg", 2003, "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterId",
                table: "Characters",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Characters_CharacterId",
                table: "Characters",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
