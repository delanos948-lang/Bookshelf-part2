using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;
    [Range(1, 5000)]
    public int Pages { get; set; }
    public bool IsRead { get; set; }
    [Range(1, 5)]
    public int? Rating { get; set; }
}
