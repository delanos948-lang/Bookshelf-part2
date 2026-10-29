using Bookshelf.Data;
using Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Controllers;

public class BooksController : Controller
{
    private readonly AppDbContext _db;
    public BooksController(AppDbContext db) => _db = db;

    [HttpGet("books")]
    public IActionResult Index() => View(_db.Books.OrderBy(book => book.Id).ToList());

    [HttpGet("books/{id:int}")]
    public IActionResult Details(int id)
    {
        Book? book = _db.Books.Find(id);
        if (book is null) return NotFound();
        ViewBag.LastId = _db.Books.Count();
        return View(book);
    }

    [HttpGet("books/new")]
    public IActionResult New() => View(new Book());

    [HttpPost("books/add")]
    [ValidateAntiForgeryToken]
    public IActionResult Add([Bind("Title,Author,Pages,IsRead,Rating")] Book book)
    {
        if (!ModelState.IsValid) return View("New", book);
        _db.Books.Add(book);
        _db.SaveChanges();
        TempData["Message"] = $"Added {book.Title}";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("books/{id:int}/mark-read")]
    public IActionResult MarkRead(int id)
    {
        Book? book = _db.Books.Find(id);
        if (book is null) return NotFound();
        book.IsRead = true;
        _db.SaveChanges();
        TempData["Message"] = $"Marked {book.Title} as read";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("books/{id:int}/mark-unread")]
    public IActionResult MarkUnread(int id)
    {
        Book? book = _db.Books.Find(id);
        if (book is null) return NotFound();
        book.IsRead = false;
        _db.SaveChanges();
        TempData["Message"] = $"Marked {book.Title} as unread";
        return RedirectToAction(nameof(Index));
    }
}
