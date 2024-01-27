using Bookstore.data;
using Bookstore.model;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Pages
{
    public class BookModel : PageModel
    {
        private static readonly int pageSize = 10;
        private readonly IBookService bookService;

        public BookModel(IBookService bookService)
        {
            this.bookService = bookService;
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

            BooksPage = await bookService.GetPageBooks(sortOrder, pageIndex ?? 1, pageSize);
        }

    }
}
