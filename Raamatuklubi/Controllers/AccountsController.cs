using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raamatuklubi.Core.Domain;
using Raamatuklubi.Data;
using Raamatuklubi.Models.Accounts;

namespace Raamatuklubi.Controllers
{
    public class AccountsController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RaamatuklubiDbContext _context;

        public AccountsController
            (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RaamatuklubiDbContext context
            )
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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    IsAdmin = model.IsAdmin,
                    DisplayName = model.DisplayName
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }
    }
}
