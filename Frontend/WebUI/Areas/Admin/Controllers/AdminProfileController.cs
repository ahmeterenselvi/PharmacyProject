using DtoLayer.Profile;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetUserByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            ResultUserDto resultUserDto = new ResultUserDto()
            {
                Name = user.Name,
                Surname = user.Surname,
                Mail = user.Email,
                City = user.City,
                District = user.District,
                PhoneNumber = user.PhoneNumber,
                TurkishIdentityNumber = user.TurkishIdentityNumber,
                Username = user.UserName,
                ImageUrl = user.ImageUrl
            };

            return View(resultUserDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await GetUserByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UpdateUserDto
            {
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                District = user.District,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateUserDto);
            }

            var user = await GetUserByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updateUserDto.Name;
            user.Surname = updateUserDto.Surname;
            if (!string.IsNullOrWhiteSpace(updateUserDto.Password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, updateUserDto.Password);
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("UpdateProfile", "AdminProfileController");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(updateUserDto);
        }

        private async Task<AppUser> GetUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }
    }
}
