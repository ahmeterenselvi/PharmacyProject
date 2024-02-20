using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult _HeadPartial() => PartialView();

        public IActionResult _PreloaderPartial() => PartialView();

        public IActionResult _NavheaderPartial() => PartialView();

        public IActionResult _HeaderPartial() => PartialView();

        public IActionResult _SidebarPartial() => PartialView();

        public IActionResult _FooterPartial() => PartialView();

        public IActionResult _ScriptPartial() => PartialView();
    }
}
