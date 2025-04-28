using Microsoft.AspNetCore.Mvc;
using PBL3.Models; // nhớ using namespace model

namespace PBL3.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý logic đăng ký ở đây (ví dụ lưu DB, kiểm tra trùng Username, ...)

                // Nếu đăng ký thành công thì chuyển hướng đến trang khác
                return RedirectToAction("Login"); // ví dụ sau khi đăng ký xong, quay về Login
            }

            // Nếu có lỗi -> return lại view để hiện lỗi
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
