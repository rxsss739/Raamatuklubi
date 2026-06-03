using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raamatuklubi.Core.Domain;
using Raamatuklubi.Data;
using Raamatuklubi.Models.BookClubs;
using System.Security.Claims;

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
                Id = x.Id,
                EventName = x.EventName,
                EventDescription = x.EventDescription,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Attendees = x.Attendees
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

        [HttpGet]
        public async Task<IActionResult> JoinEvent(Guid id)
        {

            var bookClubEvent = await _context.BookClubs
                .FirstOrDefaultAsync(e => e.Id == id);

            if (bookClubEvent == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            bookClubEvent.Attendees.Add(user.Id.ToString());

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(OngoingEvents));
        }
    }
}
