using Bookstore.model;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages.Books
{
    public class BookDetailsModel : PageModel
    {
        private readonly IBookService bookService;

        public BookDetailsModel(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await bookService.GetBook((int)id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
