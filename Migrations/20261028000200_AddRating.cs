using Bookshelf.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("20261028000200_AddRating")]
public class AddRating : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
        => migrationBuilder.AddColumn<int>(name: "Rating", table: "Books", type: "int", nullable: true);

    protected override void Down(MigrationBuilder migrationBuilder)
        => migrationBuilder.DropColumn(name: "Rating", table: "Books");

    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "8.0.11");
        modelBuilder.HasAnnotation("Relational:MaxIdentifierLength", 128);
        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
        modelBuilder.Entity("Bookshelf.Models.Book", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("int");
            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));
            b.Property<string>("Title").IsRequired().HasColumnType("nvarchar(max)");
            b.Property<string>("Author").IsRequired().HasColumnType("nvarchar(max)");
            b.Property<int>("Pages").HasColumnType("int");
            b.Property<bool>("IsRead").HasColumnType("bit");
            b.Property<int?>("Rating").HasColumnType("int");
            b.HasKey("Id");
            b.ToTable("Books");
            b.HasData(
                new { Id = 1, Title = "JoJo's Bizarre Adventure: Part 1 - Phantom Blood, Vol. 1", Author = "Hirohiko Araki", Pages = 256, IsRead = true },
                new { Id = 2, Title = "Jujutsu Kaisen, Vol. 1", Author = "Gege Akutami", Pages = 192, IsRead = false },
                new { Id = 3, Title = "Dragon Ball, Vol. 1", Author = "Akira Toriyama", Pages = 192, IsRead = true },
                new { Id = 4, Title = "Naruto, Vol. 1", Author = "Masashi Kishimoto", Pages = 192, IsRead = true },
                new { Id = 5, Title = "One Piece, Vol. 1", Author = "Eiichiro Oda", Pages = 216, IsRead = false },
                new { Id = 6, Title = "Bleach, Vol. 1", Author = "Tite Kubo", Pages = 192, IsRead = true }
            );
        });
    }
}
