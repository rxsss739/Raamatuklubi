using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raamatuklubi.Core.Domain;
using Raamatuklubi.Data;
using Raamatuklubi.Models.Books;

namespace Raamatuklubi.Controllers
{
    public class BooksController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RaamatuklubiDbContext _context;

        public BooksController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RaamatuklubiDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;   
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddBook()
        {
            BookCreateViewModel vm = new BookCreateViewModel();
            return View("AddBook", vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBook(BookCreateViewModel vm)
        {
            var user = await _userManager.GetUserAsync(User);

            Book book = new Book();
            book.ID = Guid.NewGuid();
            book.UserAddedID = Guid.Parse(user.Id);
            book.Title = vm.Title;
            book.Year = vm.Year;
            book.Comments = new List<Comment> { };
            book.EntryCreatedAt = DateTime.Now;
            book.EntryModifiedAt = DateTime.Now;

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
