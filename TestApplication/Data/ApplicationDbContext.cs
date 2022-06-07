using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApplication.Models;

namespace TestApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artist>().ToTable("Artists");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Song>().ToTable("Songs");

            modelBuilder.Entity<Artist>().HasData(
                new Artist 
                { 
                    ArtistId = 1, 
                    Name = "Backstreet Boys" 
                },
                new Artist 
                { 
                    ArtistId = 2, 
                    Name = "Test" 
                });
            modelBuilder.Entity<Genre>().HasData(
                new Genre 
                { 
                    GenreId = 1, 
                    Name = "POP" 
                },
                new Genre 
                { 
                    GenreId = 2, 
                    Name = "Disco" 
                });
            modelBuilder.Entity<Song>().HasData(
                new Song 
                { 
                    SongId = 1, 
                    Name = "Nobody Else", 
                    ArtistId = 1, 
                    GenreId = 1, 
                    Time = 3.35, 
                    Popularity = 5, 
                    Price = 105.55 
                },
                new Song 
                { 
                    SongId = 2, 
                    Name = "Breathe", 
                    ArtistId = 2, 
                    GenreId = 2, 
                    Time = 5.55, 
                    Popularity = 3, 
                    Price = 155.55 
                });
        }
    }
}
