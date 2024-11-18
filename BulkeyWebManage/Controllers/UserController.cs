using BulkeyWebManage.Application.Interfaces;
using BulkeyWebManage.Application.Service;
using BulkeyWebManage.DataAccess.DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulkeyWebManage.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        public UserController(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }
        [Route("signin-google")]
        public IActionResult SignInGoogle()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
                return RedirectToAction("AdminLogin", "Home");

            var claims = authenticateResult.Principal.Identities.FirstOrDefault()?.Claims;

            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var nameEncoded = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var name = System.Net.WebUtility.HtmlDecode(nameEncoded);

            TempData["username"] = name;
            TempData["email"] = email;

            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
