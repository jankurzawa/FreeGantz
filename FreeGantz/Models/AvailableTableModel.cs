using System.ComponentModel.DataAnnotations;

namespace FreeGantz.Models
{
    public class AvailableTableModel
    {
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "The name must contains only letters")]
        [MinLength(3, ErrorMessage = "Provide minimum 3 characters")]
        [Required(ErrorMessage = "This field is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Wrong email format")]
        public string? Email { get; set; }
        public int NumberOfGuest { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationHours ReservationHours { get; set; }
        public int TableSize { get; set; }
        public string? Description { get; set; }
        public Guid TableId { get; set; }
    }
}