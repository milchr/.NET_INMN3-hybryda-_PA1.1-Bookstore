using Microsoft.AspNetCore.Mvc;

namespace Bookstore.controller
{
    public class BookstoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
