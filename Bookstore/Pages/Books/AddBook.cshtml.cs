using Bookstore.data;
using Bookstore.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Pages.Books
{
    public class AddBookModel : PageModel
    {
        private readonly BookstoreContext _context;
        public AddBookModel(BookstoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book? Book { get; set; }


        public async Task<IActionResult> OnPost()
        {
            await Console.Out.WriteLineAsync("test");
            if (Book != null) {
                var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.FirstName.Equals(Book.Author.FirstName) && a.LastName.Equals(Book.Author.LastName));
                if (author != null)
                {
                    author.Books.Add(Book);
                }
                else {
                    Author newAuthor = new Author();
                    newAuthor.FirstName = Book.Author.FirstName;
                    newAuthor.LastName = Book.Author.LastName;
                    newAuthor.Books = new List<Book>
                    {
                        Book
                    };
                }

                _context.Books.Add(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
