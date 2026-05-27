using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raamatuklubi.Core.Domain;
using Raamatuklubi.Data;
using Raamatuklubi.Models.BookClubs;

namespace Raamatuklubi.Controllers
{
    public class BookClubsController : Controller
    {
        private readonly RaamatuklubiDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookClubsController(RaamatuklubiDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult OngoingEvents()
        {
            var result = _context.BookClubs.Select(x => new OngoingEventsViewModel
            {
                EventName = x.EventName,
                StartTime = x.StartTime,
                EndTime = x.EndTime
            })
                .OrderByDescending(x => x.StartTime);

            return View("OngoingEvents", result);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View("CreateEvent");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventViewModel vm)
        {
            var user = await _userManager.GetUserAsync(User);

            BookClub bookclub = new BookClub();
            bookclub.Id = Guid.NewGuid();
            bookclub.EventName = vm.EventName;
            bookclub.EventDescription = vm.EventDescription;
            bookclub.StartTime = vm.StartTime;
            bookclub.EndTime = vm.EndTime;
            bookclub.Location = vm.Location;
            bookclub.Organizermember = user.Id;

            await _context.BookClubs.AddAsync(bookclub);
            await _context.SaveChangesAsync();

            return RedirectToAction("OngoingEvents", "BookClubs");
        }
    }
}
