using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkeyWebManage.Models;
using BulkeyWebManage.DataAccess.DataAccess;
using Microsoft.AspNetCore.Authorization;

namespace BulkeyWebManage.Controllers;

public class HomeController : Controller
{
    private readonly BookStoreDbContext _bookStoreDbContext;
    private readonly ILogger<HomeController> _logger;
    // GET: HomeController

    public HomeController(BookStoreDbContext bookStoreDbContext, ILogger<HomeController> logger)
    {
        _bookStoreDbContext = bookStoreDbContext;
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AdminLogin()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        var email = loginRequest.Email;
        var password = loginRequest.Password;

        _logger.LogInformation("Login action started.");
        if (string.IsNullOrEmpty(email))
        {
            _logger.LogWarning("Email is empty.");
            return BadRequest("Email are required.");
        }
        if (string.IsNullOrEmpty(password))
        {
            _logger.LogWarning("Password is empty.");
            return BadRequest("Password are required.");
        }
        var user = _bookStoreDbContext.Users
           .FirstOrDefault(u => u.Email == email && u.PasswordHash == password);

        if (user != null)
        {
            _logger.LogInformation("Login successful for user: {Email}", email);
            var response = new
            {
                email = user.Email,
                username = user.UserName
            };

            return Json(response);
        }
        else
        {
            _logger.LogError("Login failed for user: {Email}", email);
            return Unauthorized("Login failed.");
        }
    }
}
