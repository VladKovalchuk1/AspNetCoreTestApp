using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using asp_mvc_app.Models;

namespace asp_mvc_app.Controllers
{
    [Area("Store")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MobileContext database;

        public HomeController(ILogger<HomeController> logger , MobileContext context)
        {
            _logger = logger;
            database = context;
        }

        public IActionResult Index()
        {
            return View(database.Phones.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Json(string name , string email , string pass)
        {
            User respose = new User { name = name, email = email, password = pass };
            return Ok(new JsonResult(respose));
        }

        public IActionResult NotFoundRoute()
        {
            return NotFound("Not Found");
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Buy(int PhoneId, string User, string Address, string ContactPhone)
        {
            Order order = new Order { User = User, Address = Address, ContactPhone = ContactPhone, PhoneId = PhoneId };
            database.Orders.Add(order);
            database.SaveChanges();
            Console.WriteLine(order.ToString());
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
