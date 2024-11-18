using BulkeyWebManage.DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkeyWebManage.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult GenreHome()
        {
            return View();
        }
    }
}
