using DapperApp.Models;
using DapperApp.Repository;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBonusRepository _bonusRepo;

        public HomeController(ILogger<HomeController> logger, IBonusRepository bonusRepo)
        {
            _logger = logger;
            _bonusRepo = bonusRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companies = _bonusRepo.GetAllCompanyWithEmployees();
            return View(companies);
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
