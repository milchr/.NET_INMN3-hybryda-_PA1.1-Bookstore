using Bookstore.model;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Pages.Books
{
    public class AddBookModel : PageModel
    {
        private readonly IBookService bookService;

        public AddBookModel(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [BindProperty]
        public Book? Book { get; set; }


        public async Task<IActionResult> OnPost()
        {

            if (Book != null) {
                await bookService.CreateBook(Book);
            }

            return RedirectToPage("./Index");
        }
    }
}
