using FilmAPI.Data.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Fellowship of the ring",
                    Genre = "Epic fantasy",
                    ReleaseYear = 2001,
                    Director = "Peter Jackson",
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a1/The_Two_Towers_cover.gif/220px-The_Two_Towers_cover.gif",
                    TrailerUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips",
                    FranchiseId = 1 
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Two Towers",
                    Genre = "Epic fantasy",
                    ReleaseYear = 2003,
                    Director = "Peter Jackson",
                    PictureUrl = "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips",
                    FranchiseId = 1 
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Return of the King",
                    Genre = "Epic fantasy",
                    ReleaseYear = 2003,
                    Director = "Peter Jackson",
                    PictureUrl = "https://example.com/returnoftheking.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips",
                    FranchiseId = 1
                }

            );
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
                    Name = "The Hobbit",
                    Description = "Another epic fantasy franchise by J.R.R. Tolkien."
                }
             );
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    FullName = "Frodo Baggins",
                    Alias = "Ring-Bearer",
                    Gender = "Male",
                    PictureUrl = "https://example.com/frodo.jpg"
                },
                new Character
                {
                    Id = 2,
                    FullName = "Aragorn",
                    Alias = "Strider",
                    Gender = "Male",
                    PictureUrl = "https://example.com/aragorn.jpg"
                },
                new Character
                {
                    Id = 3,
                    FullName = "Gandalf",
                    Alias = "Mithrandir",
                    Gender = "Male",
                    PictureUrl = "https://example.com/gandalf.jpg"
                }
            );
        }
    }
}




