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


        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }
    }
}
