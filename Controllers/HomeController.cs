using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LazyLoading.Models;
using LazyLoading.Data;

namespace LazyLoading.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var sensors = _context.Sensors.ToList();

            //var sensors = _context.Sensors.Select(s => new Sensor
            //{
            //    Id = s.Id,
            //    SensorName = s.SensorName,
            //    SensorType = s.SensorType
            //}).ToList() ;

            stopwatch.Stop();

            var timeElapsed = stopwatch.Elapsed;

            ViewBag.TimeTaken = timeElapsed.TotalSeconds + " seconds";

            return View(sensors);

            //1. Disable lazy loading
            //2. Load selected columns
            //3. Disable query tracking

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
