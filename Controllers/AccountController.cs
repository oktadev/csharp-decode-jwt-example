using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DecodeJWTs.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge("OpenIdConnect");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return new SignOutResult(new[]
            {
                "OpenIdConnect",
                CookieAuthenticationDefaults.AuthenticationScheme
            });
        }

        public IActionResult AccessDenied()
        {
            return Content("Access denied");
        }

    }
}