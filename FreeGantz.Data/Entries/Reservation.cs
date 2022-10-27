namespace FreeGantz.Data.Entries
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public DateTime Day { get; set; }
        public ReservationHours ReservationHour { get; set; }

        [Required]
        [RegularExpression(@"^(?=[A-Z]{1,1}[a-z]{1,}\s[A-Z]{1,1}[a-z]{1,}).{5,50}$", ErrorMessage = "Not valid name")]
        [StringLength(50, MinimumLength = 5)]
        public string NameOfClient { get; set; }

        [Required]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Not valid e-mail")]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        public Table Table { get; set; }
        public Guid TableId { get; set; }

        public Reservation()
            => Id = Guid.NewGuid();

        public Reservation(DateTime day, ReservationHours reservationHours, string nameOfClient, string customerEmail, Guid tableId)
        {
            Id = Guid.NewGuid();
            Day = day;
            ReservationHour = reservationHours;
            NameOfClient = nameOfClient;
            CustomerEmail = customerEmail;
            TableId = tableId;
        }
    }
}
