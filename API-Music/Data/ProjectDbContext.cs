using API_Music.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace API_Music.Data
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Music> Musics { get; set; }
        private readonly IConfiguration _configuration;
        public ProjectDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CONECTION_DATABASE"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Artist
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");
                entity.HasKey(a => a.Id);
                entity
                    .Property(a => a.Name)
                    .HasMaxLength(60)
                    .IsRequired();

                entity
                    .Property(a => a.Alias)
                    .HasMaxLength(200);

                entity
                    .Property(a => a.PhotoUrl);

                entity
                    .Property(a => a.CountryFrom);
            });

            // Music
            modelBuilder.Entity<Music>(entity =>
            {
                entity.ToTable("Music");
                entity.HasKey(m => m.Id);
                entity
                    .Property(m => m.Name)
                    .HasMaxLength(120)
                    .IsRequired();

                entity
                    .Property(m => m.Duration)
                    .IsRequired();

                entity
                    .HasOne<Artist>(m => m.Artist)
                    .WithMany(a => a.Musics)
                    .HasForeignKey(m => m.ArtistId);

                entity
                    .HasOne<Album>(m => m.Album)
                    .WithMany(a => a.Musics)
                    .HasForeignKey(m => m.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Album
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");
                entity.HasKey(a => a.Id);
                entity
                    .Property(a => a.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity
                    .Property(a => a.YearLaunch);

                entity
                    .Property(a => a.CoverUrl);

                entity
                    .HasOne<Artist>(album => album.Artist)
                    .WithMany(artist => artist.Albums)
                    .HasForeignKey(album => album.ArtistId);

                entity
                    .HasData(new[] {
                    new Artist
                    {
                        Id = 1,
                        Name = "Eminem",
                        Alias = "Slim shady",
                        PhotoUrl = "https://en.wikipedia.org/wiki/File:Eminem_-_Concert_for_Valor_in_Washington,_D.C._Nov._11,_2014_(2)_(Cropped).jpg",
                        CountryFrom = "United States of America",
                    }
                    });
            });
        }
    }
}
