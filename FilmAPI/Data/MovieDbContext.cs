
using FilmAPI.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace FilmAPI.Data

{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
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
                    Director = "Petter Jackson",
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a1/The_Two_Towers_cover.gif/220px-The_Two_Towers_cover.gif",
                    TrailerUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips",
                    FranchiseId = 1 
                },
                new Movie
                {
                    Id = 2,
                    Title = "Two towers",
                    Genre = "Epic fantasy",
                    ReleaseYear = 2003,
                    Director = "Petter Jackson",
                    PictureUrl = "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_.jpg",
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




