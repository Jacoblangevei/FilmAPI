using FilmAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        // Seeds
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Fellowship of the ring",
                    Genre = "Epic fantasy",
                    ReleaseYear = 2001,
                    Director = "Peter Jackson",
                    PictureUrl = "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips",
                    FranchiseId = 1 
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Two Towers",
                    Genre = "Epic fantasy",
                    ReleaseYear = 2002,
                    Director = "Peter Jackson",
                    PictureUrl = "https://m.media-amazon.com/images/M/MV5BZGMxZTdjZmYtMmE2Ni00ZTdkLWI5NTgtNjlmMjBiNzU2MmI5XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_FMjpg_UX1000_.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=hYcw5ksV8YQ",
                    FranchiseId = 1 
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Return of the King",
                    Genre = "Epic fantasy",
                    ReleaseYear = 2003,
                    Director = "Peter Jackson",
                    PictureUrl = "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=r5X-hFf6Bwo",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 4,
                    Title = "Star Wars Episode IV: A New Hope",
                    Genre = "Space opera",
                    ReleaseYear = 1977,
                    Director = "George Lucas",
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=1g3_CFmnU7k",
                    FranchiseId = 2
                },
                new Movie
                {
                    Id = 5,
                    Title = "Star Wars Episode V: The Empire Strikes Back",
                    Genre = "Space opera",
                    ReleaseYear = 1980,
                    Director = "Irvin Kershner",
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/en/3/3c/SW_-_Empire_Strikes_Back.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=JNwNXF9Y6kY",
                    FranchiseId = 2
                },  
                new Movie
                {
                    Id = 6,
                    Title = "Star Wars Episode VI: Return of the Jedi",
                    Genre = "Space opera",
                    ReleaseYear = 1983,
                    Director = "Richard Marquand",
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/en/b/b2/ReturnOfTheJediPoster1983.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=7L8p7_SLzvU",
                    FranchiseId = 2
                },
                new Movie
                {
                    Id = 7,
                    Title = "Harry Potter and the Philosopher's Stone",
                    Genre = "Fantasy",
                    ReleaseYear = 2001,
                    Director = "Chris Columbus",
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/en/b/bf/Harry_Potter_and_the_Philosopher%27s_Stone_posters.JPG",
                    TrailerUrl = "https://www.youtube.com/watch?v=VyHV0BRtdxo",
                    FranchiseId = 3
                },
                new Movie
                {
                    Id = 8,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Genre = "Fantasy",
                    ReleaseYear = 2002,
                    Director = "Chris Columbus",
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/en/c/c0/Harry_Potter_and_the_Chamber_of_Secrets_movie.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=1bq0qff4iF8",
                    FranchiseId = 3
                },
                new Movie
                {
                    Id = 9,
                    Title = "Harry Potter and the Prisoner of Azkaban",
                    Genre = "Fantasy",
                    ReleaseYear = 2004,
                    Director = "Alfonso Cuarón",
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Prisoner_of_azkaban_UK_poster.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=lAxgztbYDbs",
                    FranchiseId = 3
                },
                new Movie
                {
                    Id = 10,
                    Title = "Harry Potter and the Goblet of Fire",
                    Genre = "Fantasy",
                    ReleaseYear = 2005,
                    Director = "Mike Newell",
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/en/c/c9/Harry_Potter_and_the_Goblet_of_Fire_Poster.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=PFWAOnvMd1Q",
                    FranchiseId = 3
                }
            );

            // Franchises
            modelBuilder.Entity<Franchise>().HasData(
                new Franchise
                {
                    Id = 1,
                    Name = "Lord of the Rings",
                    Description = "The epic fantasy franchise based on J.R.R. Tolkien's novels."
                },
                new Franchise
                {
                    Id = 2,
                    Name = "Star Wars",
                    Description = "The iconic space opera franchise created by George Lucas."
                },
                new Franchise
                {
                    Id = 3,
                    Name = "Harry Potter",
                    Description = "The fantasy franchise based on J.K. Rowling's novels."
                }
             );

            // Characters
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    FullName = "Frodo Baggins",
                    Alias = "Ring-Bearer",
                    Gender = "Male",
                    PictureUrl = "https://static.wikia.nocookie.net/lotr/images/3/32/Frodo_%28FotR%29.png/revision/latest?cb=20221006065757"
                },
                new Character
                {
                    Id = 2,
                    FullName = "Aragorn",
                    Alias = "Strider",
                    Gender = "Male",
                    PictureUrl = "https://static.wikia.nocookie.net/warner-bros-entertainment/images/6/6a/94E54497-FAC0-4332-9531-27A0A5962043.jpeg/revision/latest?cb=20190108035325"
                },
                new Character
                {
                    Id = 3,
                    FullName = "Sméagol",
                    Alias = "Gollum",
                    Gender = "Male",
                    PictureUrl = "https://pyxis.nymag.com/v1/imgs/5d4/f6e/c6aeaba039ba41d69a9dbce8c3523ec471-11-gollum.rsquare.w700.jpg"
                },
                new Character
                {
                    Id = 4,
                    FullName = "Luke Skywalker",
                    Alias = "The Chosen One",
                    Gender = "Male",
                    PictureUrl = "https://static.wikia.nocookie.net/starwars/images/2/20/LukeTLJ.jpg/revision/latest?cb=20170927045449"
                },
                new Character
                {
                    Id = 5,
                    FullName = "Obi-Wan Kenobi",
                    Alias = "Ben Kenobi",
                    Gender = "Male",
                    PictureUrl = "https://static.wikia.nocookie.net/starwars/images/4/4e/ObiWanHS-SWE.jpg/revision/latest?cb=20111126060943"
                },
                new Character
                {
                    Id = 6,
                    FullName = "Anakin Skywalker",
                    Alias = "Darth Vader",
                    Gender = "Male",
                    PictureUrl = "https://imageio.forbes.com/specials-images/imageserve/6090f7f251c9c6c605e612fc/Darth-Vader/0x0.jpg?format=jpg&crop=3127,1759,x0,y33,safe&width=960"
                },
                new Character
                {
                    Id = 7,
                    FullName = "Harry James Potter",
                    Alias = "The Boy Who Lived",
                    Gender = "Male",
                    PictureUrl = "https://static.wikia.nocookie.net/harrypotter/images/0/0e/Harry_James_Potter.jpg/revision/latest?cb=20150808063507"
                },
                new Character
                {
                    Id = 8,
                    FullName = "Tom Marvolo Riddle",
                    Alias = "Lord Voldemort",
                    Gender = "Male",
                    PictureUrl = "https://static.wikia.nocookie.net/harrypotter/images/4/4b/VoldemortHeadshot_DHP1.png/revision/latest?cb=20161223175148"
                },
                new Character
                {
                    Id = 9,
                    FullName = "Albus Percival Wulfric Brian Dumbledore",
                    Alias = "Professor Dumbledore",
                    Gender = "Male",
                    PictureUrl = "https://static.wikia.nocookie.net/harrypotter/images/5/5e/Albus_Dumbledore_%28HBP_promo%29_2.jpg/revision/latest?cb=20150808063507"
                }
            );
        }
    }
}