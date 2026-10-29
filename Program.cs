using Bookshelf.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookshelfDb")));
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/books"));
app.Run();
