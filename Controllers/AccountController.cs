using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebTruyen.Models;
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    // Model cho đăng nhập
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    // Model cho đổi mật khẩu
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.NguoiDungs
                .FirstOrDefaultAsync(u => u.Name == model.Username &&
                                        u.Password == model.Password);

            if (user != null)
            {
                // Lưu thông tin đăng nhập vào session
                HttpContext.Session.SetInt32("UserId", user.ID);
                HttpContext.Session.SetString("Username", user.Name);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (!userId.HasValue)
            return RedirectToAction("Login");

        var user = await _context.NguoiDungs
            .Include(u => u.Truyen_Users)
                .ThenInclude(td => td.Truyen)
            .FirstOrDefaultAsync(u => u.ID == userId);

        return View(user);
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Login");

            var user = await _context.NguoiDungs.FindAsync(userId.Value);
            if (user.Password != model.OldPassword)
            {
                ModelState.AddModelError("", "Mật khẩu cũ không đúng");
                return View(model);
            }

            user.Password = model.NewPassword;
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", new { message = "Đổi mật khẩu thành công" });
        }
        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}