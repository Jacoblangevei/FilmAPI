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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeds
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
                }
            );
        }
    }
}