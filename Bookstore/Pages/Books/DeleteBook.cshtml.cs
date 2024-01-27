using Bookstore.model;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Pages.Books
{
    public class DeleteBookModel : PageModel
    {
        private readonly IBookService bookService;

        public DeleteBookModel(IBookService bookService)
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

            await bookService.DeleteBook((int)id);

            return RedirectToPage("./Index");
        }
    }
}
