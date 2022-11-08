using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using WebApplicationSignalR.Hubs;
using WebApplicationSignalR.Models;

namespace WebApplicationSignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DeathlyHallowSub> _deathlyHub;

        public HomeController(ILogger<HomeController> logger, IHubContext<DeathlyHallowSub> deathlyHub)
        {
            _logger = logger;
            _deathlyHub = deathlyHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }

        public IActionResult DeathlyHallow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HarryPotterHouse()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> DeathlyHallowRace(string type)
        {
            if (StaticData.DeathlyHallowRace.ContainsKey(type))
            {
                StaticData.DeathlyHallowRace[type]++;
            }
            await _deathlyHub.Clients.All.SendAsync("updateDeathlyHallowCount",
                StaticData.DeathlyHallowRace[StaticData.Cloak],
                StaticData.DeathlyHallowRace[StaticData.Stone],
                StaticData.DeathlyHallowRace[StaticData.Wand]);
            return Accepted();

        }
    }
}