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
        private readonly RoleManager<AppRole> _roleManager;

        public AdminRegisterController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index() => View(new CreateNewUserDto());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CreateNewUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            var appUser = MapToAppUser(userDto);

            var result = await _userManager.CreateAsync(appUser, userDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(userDto);
            }

            await AssignUserRoleAsync(appUser, "Pharmacist");

            return RedirectToAction("Index", "AdminLogin", new { area = "Admin" });
        }

        private AppUser MapToAppUser(CreateNewUserDto userDto)
        {
            return new AppUser
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Mail,
                UserName = userDto.Username,
                TurkishIdentityNumber = userDto.TurkishIdentityNumber
            };
        }

        private async Task AssignUserRoleAsync(AppUser user, string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                throw new InvalidOperationException($"Role '{roleName}' does not exist.");
            }

            await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}
