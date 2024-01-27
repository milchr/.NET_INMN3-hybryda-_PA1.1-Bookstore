using Bookstore.model;
using Bookstore.Pages;
using System.Drawing.Printing;

namespace Bookstore.Services
{
    public interface IBookService
    {
        Task<Book> GetBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task DeleteBook(int id);
        Task<Page<Book>> GetPageBooks(string sortOrder, int? pageIndex, int pageSize);
    }
}
