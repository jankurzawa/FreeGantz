namespace FreeGantz.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
            => View();

        [HttpGet]
        public IActionResult AboutUs()
            => View();

        [HttpGet]
        public IActionResult Booking()
            => View();

        [HttpGet]
        public IActionResult Contact()
            => View();

        [HttpGet]
        public IActionResult Menu()
            => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statuscode)
        {
            if (statuscode == 404)
                return View("404");
            else
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}