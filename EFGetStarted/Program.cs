using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");
await PrintState("start");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
await db.SaveChangesAsync();
await PrintState("after insert");

// Read
Console.WriteLine("Querying for a blog");
var blog = await db.Blogs
    .OrderBy(b => b.BlogId)
    .FirstAsync();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
await db.SaveChangesAsync();
await PrintState("after update");

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
await db.SaveChangesAsync();
await PrintState("after delete");

// Fresh query against the database (no tracking) so we see what is actually stored
async Task PrintState(string step)
{
    var blogs = await db.Blogs.AsNoTracking().Include(b => b.Posts).ToListAsync();
    Console.WriteLine($"[{step}] {blogs.Count} blog(s), {blogs.Sum(b => b.Posts.Count)} post(s)");
    foreach (var b in blogs)
        Console.WriteLine($"  {b.BlogId}: {b.Url} ({b.Posts.Count} posts)");
}
