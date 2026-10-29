using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Character> Characters => Set<Character>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Character>().HasData(
            new Character { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero" },
            new Character { Id = 2, Name = "Link", Game = "The Legend of Zelda.", Role = "Hero" },
            new Character { Id = 3, Name = "Bowser", Game = "Super Mario Bros.", Role = "Villain" },
            new Character { Id = 4, Name = "Zelda", Game = "The Legend of Zelda.", Role = "Princess" }
        );
    }
}