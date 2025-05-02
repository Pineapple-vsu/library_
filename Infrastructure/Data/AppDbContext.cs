using library.Entity;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace library.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookStatus> BookStatus { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookCopy> BookCopy { get; set; }
        public DbSet<History> History { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }
    }
}
