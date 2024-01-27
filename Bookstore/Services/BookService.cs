using Bookstore.data;
using Bookstore.model;
using Bookstore.Pages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services
{
    public class BookService : IBookService
    {
        private readonly BookstoreContext _context;

        public BookService(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateBook(Book book)
        {
            var author = await _context.Authors.Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.FirstName.Equals(book.Author.FirstName) && a.LastName.Equals(book.Author.LastName));

            if (author != null)
            {
                author.Books.Add(book);
            }
            else
            {
                Author newAuthor = new Author();
                newAuthor.FirstName = book.Author.FirstName;
                newAuthor.LastName = book.Author.LastName;
                newAuthor.Books = new List<Book>
                    {
                        book
                    };
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public Task<List<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Page<Book>> GetPageBooks(string sortOrder, int? pageNumber, int pageSize, string filter)
        {
            var books = _context.Books.Include(b => b.Author).AsSingleQuery();

            if (!String.IsNullOrEmpty(filter))
            {
                books = books.Where(b => b.Title.ToUpper().Contains(filter.ToUpper()));
            }

            switch (sortOrder)
            {
                case "title":
                    books = books.OrderBy(s => s.Title);
                    break;
                case "Date":
                    books = books.OrderBy(s => s.PublishDate);
                    break;
                case "date_desc":
                    books = books.OrderByDescending(s => s.PublishDate);
                    break;
                default:
                    books = books.OrderBy(s => s.Id);
                    break;
            }

            return await Page<Book>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var bookToUpdate = await _context.Books.FindAsync(book.Id);

            if (bookToUpdate == null)
            {
                return null;
            }

            bookToUpdate.Title = book.Title;
            bookToUpdate.Description = book.Description;
            bookToUpdate.PublishDate = book.PublishDate;

            _context.Books.Update(bookToUpdate);
            await _context.SaveChangesAsync();

            return bookToUpdate;
        }
    }
}
