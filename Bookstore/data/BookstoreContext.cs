using Bookstore.model;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.data
{
    public class BookstoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookstoreContext(DbContextOptions options) : base(options)
        {
        }
    }
}
