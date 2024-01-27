using Bookstore.data;
using Bookstore.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Bookstore.Pages
{
    public class BookModel : PageModel
    {
        private static readonly int pageSize = 10;
        private readonly BookstoreContext _context;


        public BookModel(BookstoreContext context)
        {
            _context = context;
        }

        public string TitleSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }

        public Page<Book> BooksPage { get; set; }

        public IList<Book>? Books { get; set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";


            var books = _context.Books.Include(b => b.Author).AsSingleQuery();

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

            BooksPage = await Page<Book>.CreateAsync(books.AsNoTracking(), pageIndex ?? 1, pageSize);
        }

    }
}
