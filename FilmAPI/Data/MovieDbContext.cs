
using FilmAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace FilmAPI.Data

{
    public class MovieDbContext : DbContext
    {

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Characters> Characters { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and other model-specific settings here
            modelBuilder.Entity<MovieCharacter>()
                .HasKey(mc => new { mc.MovieId, mc.CharacterId });

            modelBuilder.Entity<MovieCharacter>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCharacters)
                .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Entity<MovieCharacter>()
                .HasOne(mc => mc.Character)
                .WithMany(c => c.MovieCharacters)
                .HasForeignKey(mc => mc.CharacterId);
        }
    }
}




