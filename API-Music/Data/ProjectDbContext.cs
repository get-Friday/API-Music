using API_Music.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Music.Data
{
    public class ProjectDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ProjectDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Music> Musics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("CONECTION_DATABASE")
            );
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

                entity
                    .HasData(new[]
                    {
                        new Artist{
                            Id = 1,
                            Name = "Marshall Bruce Mathers III",
                            Alias = "Eminem",
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Eminem_-_Concert_for_Valor_in_Washington%2C_D.C._Nov._11%2C_2014_%282%29_%28Cropped%29.jpg/220px-Eminem_-_Concert_for_Valor_in_Washington%2C_D.C._Nov._11%2C_2014_%282%29_%28Cropped%29.jpg",
                            CountryFrom = "United States of America"
                        },
                        new Artist
                        {
                            Id = 2,
                            Name = "Calvin Cordozar Broadus Jr.",
                            Alias = "Snoop Dogg",
                            PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/17/Snoop_Dogg_2019_by_Glenn_Francis.jpg/220px-Snoop_Dogg_2019_by_Glenn_Francis.jpg",
                            CountryFrom = "United States of America"
                        }
                    });
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
        }
    }
}
