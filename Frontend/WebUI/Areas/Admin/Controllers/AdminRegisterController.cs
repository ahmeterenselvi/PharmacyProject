using DtoLayer.RegisterDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminRegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminRegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index() => View(new CreateNewUserDto());

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            var appUser = new AppUser()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Mail,
                UserName = userDto.Username,
                TurkishIdentityNumber=userDto.TurkishIdentityNumber
            };

            var result = await _userManager.CreateAsync(appUser, userDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(userDto);
            }

            return RedirectToAction("Index", "AdminLogin", new { area = "Admin" });
        }
    }
}
