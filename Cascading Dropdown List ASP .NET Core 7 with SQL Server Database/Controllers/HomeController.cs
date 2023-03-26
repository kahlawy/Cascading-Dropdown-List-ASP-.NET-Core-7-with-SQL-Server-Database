using Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}