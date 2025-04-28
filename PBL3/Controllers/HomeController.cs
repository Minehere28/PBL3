using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PBL3.Data;
using PBL3.Models; // ??m b?o b?n có model n?u c?n thi?t

namespace PBL3.Controllers
{
    public class HomeController : Controller

    {

        private readonly ILogger<HomeController> _logger;
        private readonly BMContext _bMContext;

        public HomeController(ILogger<HomeController> logger, BMContext _bmContext)
        {
            _logger = logger;
            this._bMContext = _bmContext;
        }

        // Action tr? v? view chính (Index)
        public IActionResult Index()
        {
            return View();
        }

        // Action tr? v? view ??ng nh?p (Login)
        [HttpGet]
        public IActionResult Login()
        {
            return View();  // Tr? v? Login.cshtml
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var account = _bMContext.Users.FirstOrDefault(a => a.Sdt == model.Username && a.PasswordHash == model.Password);
            if (account == null)
            {
                ModelState.AddModelError("", "S? ?i?n tho?i ho?c ID không chính xác.");
                return View(model);
            }
            TempData["Username"] = model.Username;
            TempData["Password"] = model.Password;
            return RedirectToAction("Index");
        }


        // Action tr? v? view Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Action tr? v? view Error (n?u có l?i)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
