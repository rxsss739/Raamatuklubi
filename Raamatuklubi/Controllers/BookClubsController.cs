using Microsoft.AspNetCore.Mvc;
using Raamatuklubi.Data;
using Raamatuklubi.Models.BookClubs;

namespace Raamatuklubi.Controllers
{
    public class BookClubsController : Controller
    {
        private readonly RaamatuklubiDbContext _context;

        public BookClubsController(RaamatuklubiDbContext context)
        {
            _context = context;
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
    }
}
