using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data;

public class VideoGameDbContext : DbContext
{
    public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options)
        : base(options) { }

    public DbSet<VideoGame> VideoGames => Set<VideoGame>();

    public DbSet<VideoGameDetails> VideoGameDetails => Set<VideoGameDetails>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .Entity<VideoGame>()
            .HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "Spiderman 2",
                    Platform = "PS5",
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive Entertainment",
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "The Legend of Zelda: Breath of the Wild",
                    Platform = "Nintendo Switch",
                    Developer = "Nintendo EPD",
                    Publisher = "Nintendo",
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "Cyberpunk 2077",
                    Platform = "PC",
                    Developer = "CD Projekt Red",
                    Publisher = "CD Projekt",
                }
            );
    }
}
