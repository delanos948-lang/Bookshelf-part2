using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "JoJo's Bizarre Adventure: Part 1 - Phantom Blood, Vol. 1", Author = "Hirohiko Araki", Pages = 256, IsRead = true },
            new Book { Id = 2, Title = "Jujutsu Kaisen, Vol. 1", Author = "Gege Akutami", Pages = 192, IsRead = false },
            new Book { Id = 3, Title = "Dragon Ball, Vol. 1", Author = "Akira Toriyama", Pages = 192, IsRead = true },
            new Book { Id = 4, Title = "Naruto, Vol. 1", Author = "Masashi Kishimoto", Pages = 192, IsRead = true },
            new Book { Id = 5, Title = "One Piece, Vol. 1", Author = "Eiichiro Oda", Pages = 216, IsRead = false },
            new Book { Id = 6, Title = "Bleach, Vol. 1", Author = "Tite Kubo", Pages = 192, IsRead = true }
        );
    }
}
