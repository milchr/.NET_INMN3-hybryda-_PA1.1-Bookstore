using Bookstore.model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Bookstore.data
{
    public class BookstoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookstoreContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired();
        }
    }
}
