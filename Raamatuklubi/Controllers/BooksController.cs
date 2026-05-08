using Microsoft.AspNetCore.Mvc;
using Raamatuklubi.Core.Domain;
using Raamatuklubi.Data;
using Raamatuklubi.Models.Books;

namespace Raamatuklubi.Controllers
{
    public class BooksController : Controller
    {

        private readonly RaamatuklubiDbContext _context;

        public BooksController(RaamatuklubiDbContext context)
        {
            _context = context;   
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            BookCreateViewModel vm = new BookCreateViewModel();
            return View("AddBook", vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookCreateViewModel vm)
        {

            Book book = new Book();
            book.ID = Guid.NewGuid();
            book.Title = vm.Title;
            book.Year = vm.Year;
            book.EntryCreatedAt = DateTime.Now;
            book.EntryModifiedAt = DateTime.Now;


            var result = _context.Add(book);
            return RedirectToAction("Index", "Home");
        }
    }
}
