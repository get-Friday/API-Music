using API_Music.Models;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Artist>().HasKey(a => a.Id);
            modelBuilder.Entity<Artist>()
                .Property(a => a.Name)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<Artist>()
                .Property(a => a.Alias)
                .HasMaxLength(200);

            modelBuilder.Entity<Artist>()
                .Property(a => a.PhotoUrl);

            modelBuilder.Entity<Artist>()
                .Property(a => a.CountryFrom);

            // Music
            modelBuilder.Entity<Music>().ToTable("Music");
            modelBuilder.Entity<Music>().HasKey(m => m.Id);
            modelBuilder.Entity<Music>()
                .Property(m => m.Name)
                .HasMaxLength(120)
                .IsRequired();

            modelBuilder.Entity<Music>()
                .Property(m => m.Duration)
                .IsRequired();

            modelBuilder.Entity<Music>()
                .HasOne<Artist>(m => m.Artist)
                .WithMany(a => a.Musics)
                .HasForeignKey(m => m.ArtistId);

            modelBuilder.Entity<Music>()
                .HasOne<Album>(m => m.Album)
                .WithMany(a => a.Musics)
                .HasForeignKey(m => m.AlbumId);

            // Album
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Album>().HasKey(a => a.Id);
            modelBuilder.Entity<Album>()
                .Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Album>()
                .Property(a => a.YearLaunch);

            modelBuilder.Entity<Album>()
                .Property(a => a.CoverUrl);

            modelBuilder.Entity<Album>()
                .HasOne<Artist>(album => album.Artist)
                .WithMany(artist => artist.Albums)
                .HasForeignKey(album => album.ArtistId);
        }
    }
}
