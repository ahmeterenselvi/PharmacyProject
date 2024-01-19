using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult HeadPartial() => PartialView();

        public IActionResult PreloaderPartial() => PartialView();

        public IActionResult NavheaderPartial() => PartialView();

        public IActionResult HeaderPartial() => PartialView();

        public IActionResult SidebarPartial() => PartialView();

        public IActionResult FooterPartial() => PartialView();

        public IActionResult ScriptPartial() => PartialView();
    }
}
