namespace FreeGantz.Controllers
{
    public class BookingController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IAvailableTableModelFactory _availableTableModelFactory;

        public BookingController(IReservationRepository reservationRepository, IAvailableTableModelFactory availableTableModelFactory)
        {
            _reservationRepository = reservationRepository;
            _availableTableModelFactory = availableTableModelFactory;
        }

        [HttpGet]
        public IActionResult Booking()
            => View();

        [HttpPost]
        public IActionResult CheckBookingAvailability()
        {
            int numberOfGuest = Int32.Parse(Request.Form["numberOfPeople"].First());
            var reservationDate = Request.Form["reservationDate_date"].First();
            var validatedReservationDate = new DateConverter().ParseDateFromCalendar(reservationDate);
            var reservationTime = Request.Form["reservationDate_hour"].First();
            var validatedReservationTime = new DateConverter().ParseHour(reservationTime);
            Table table = _reservationRepository.GetTheLittlestAvailableTable(numberOfGuest, validatedReservationDate, validatedReservationTime);

            if (table == null)
                return RedirectToAction("ShowThatBookingIsNotPossible");
            else
            {
                AvailableTableModel model = _availableTableModelFactory.create(new FlatTableDto()
                {
                    TableId = table.Id,
                    TableSize = table.Size,
                    Description = table.Description
                },
                    numberOfGuest, validatedReservationDate, validatedReservationTime);
                return RedirectToAction("AvailableTable", model);
            }
        }

        [HttpGet]
        public IActionResult AvailableTable(AvailableTableModel availableTableModel)
            => View(availableTableModel);

        [HttpPost]
        public IActionResult BookReservation(AvailableTableModel availableTableModel)
        {
            _reservationRepository.AddReservation(availableTableModel.ReservationDate, availableTableModel.ReservationHours, availableTableModel.Name, availableTableModel.Email, availableTableModel.TableId);
            return View();
        }

        [HttpGet]
        public IActionResult ShowThatBookingIsNotPossible()
            => View();
    }
}
