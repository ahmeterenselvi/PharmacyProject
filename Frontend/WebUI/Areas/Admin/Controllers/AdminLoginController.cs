using DtoLayer.LoginDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        private readonly SignInManager<AppUser> _manager;

        public AdminLoginController(SignInManager<AppUser> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = await _manager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(dto);
        }

        public async Task<IActionResult> LogOut()
        {
            await _manager.SignOutAsync();

            return RedirectToAction("Index", "AdminLogin", new { area = "Admin" });
        }
    }
}
