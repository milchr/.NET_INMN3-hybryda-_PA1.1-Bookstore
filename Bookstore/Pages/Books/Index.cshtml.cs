using Bookstore.data;
using Bookstore.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Pages
{
    public class BookModel : PageModel
    {
        private readonly BookstoreContext _context;
        public BookModel(BookstoreContext context)
        {
            _context = context;
        }

        public IList<Book>? Books { get; set; }

        public async Task OnGetAsync()
        {
            var books = await _context.Books.Include(b => b.Author).ToListAsync();
            Books = books;
        }

    }
}
