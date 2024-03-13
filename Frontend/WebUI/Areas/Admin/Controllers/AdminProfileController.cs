using AutoMapper;
using DtoLayer.Profile;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AdminProfileController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetUserByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            var resultUserDto = _mapper.Map<ResultUserDto>(user);

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

            var model = _mapper.Map<UpdateUserDto>(user);

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

            _mapper.Map(updateUserDto, user);

            if (!string.IsNullOrWhiteSpace(updateUserDto.Password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, updateUserDto.Password);
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
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
