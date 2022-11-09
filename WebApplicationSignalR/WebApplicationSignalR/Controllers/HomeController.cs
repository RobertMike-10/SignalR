using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationSignalR.Data;
using WebApplicationSignalR.Hubs;
using WebApplicationSignalR.Models;

namespace WebApplicationSignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DeathlyHallowSub> _deathlyHub;
        private readonly IHubContext<OrderHub> _orderHub;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, 
            IHubContext<DeathlyHallowSub> deathlyHub,
            IHubContext<OrderHub> orderHub,
            ApplicationDbContext db)
        {
            _logger = logger;
            _deathlyHub = deathlyHub;
            _orderHub = orderHub;
            _db = db;
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

        public IActionResult BasicChat()
        {
            return View();
        }

        public IActionResult Chat()
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


        [ActionName("Order")]
        public async Task<IActionResult> Order()
        {
            string[] name = { "Mike", "Esmeralda", "Peter", "Yaneth", "Roni" };
            string[] itemName = { "Spagetti", "Lasgnia", "Pizza", "Chicken", "Salad" };

            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(name.Length);

            Order order = new Order()
            {
                Name = name[index],
                ItemName = itemName[index],
                Count = index
            };

            return View(order);
        }

        [ActionName("Order")]
        [HttpPost]
        public async Task<IActionResult> OrderPost(Order order)
        {

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            await _orderHub.Clients.All.SendAsync("newOrder");
            return RedirectToAction(nameof(Order));
        }
        [ActionName("OrderList")]
        public async Task<IActionResult> OrderList()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var productList = await _db.Orders.ToListAsync();
            return Json(new { data = productList });
        }

    }
}