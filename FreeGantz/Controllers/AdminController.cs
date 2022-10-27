namespace FreeGantz.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICredentialsRepository _credentialsRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;
        public AdminController(ICredentialsRepository credentialsRepository, IReservationRepository reservationRepository, ITableRepository tableRepository)
        {
            _credentialsRepository = credentialsRepository;
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
        }

        [HttpGet]
        public IActionResult LogIn()
            => View();
        [HttpPost]
        public IActionResult LogIn(string email, string password)
        {
            if (_credentialsRepository.CheckIfCredenrialsExsist(email, password))
                return RedirectToAction("AdminMainPanel");
            return View();
        }
        [HttpGet]
        public IActionResult AdminMainPanel()
            => View(_reservationRepository.GetTodaysReservations());
        [HttpGet]
        public IActionResult CreateNewTable()
            => View();
        [HttpPost]
        public IActionResult CreateNewTable(string size, string description)
        {
            Table table;
            try
            {
                table = new Table(int.Parse(size), description);
                _tableRepository.AddNewTable(table);
                return RedirectToAction("AdminMainPanel");
            }
            catch (Exception) { }
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ReservationToRemove = _reservationRepository.GetReservationById(id);
            if (ReservationToRemove != null)
                _reservationRepository.Delete(ReservationToRemove);
            return RedirectToAction("AdminMainPanel");
        }
    }
}
