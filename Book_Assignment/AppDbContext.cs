using Book_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Assignment
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> authors { get; set; }

        public DbSet<Book> books { get; set; }

        public DbSet<Genre> genre { get; set; }

    }
}
