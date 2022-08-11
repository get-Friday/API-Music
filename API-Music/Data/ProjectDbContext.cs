using API_Music.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Music.Data
{
    public class ProjectDbContext : DbContext
    {
        private IConfiguration _configuration;

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
                .Property(m => m.Album);

            modelBuilder.Entity<Music>()
                .Property(m => m.Artist)
                .IsRequired();

            modelBuilder.Entity<Music>()
                .HasOne<Artist>(m => m.Artist)
                .WithMany(a => a.Musics)
                .HasForeignKey(m => m.Id);
        }
    }
}
