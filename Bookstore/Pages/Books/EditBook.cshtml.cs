using Bookstore.model;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Pages.Books
{
    public class EditBookModel : PageModel
    {
        private readonly IBookService bookService;

        public EditBookModel(IBookService bookService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            await bookService.UpdateBook(Book);

            return RedirectToPage("./Index");
        }

    }
}
