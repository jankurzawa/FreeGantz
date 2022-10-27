namespace FreeGantz.Models
{
    public interface IAvailableTableModelFactory
    {
        AvailableTableModel create(FlatTableDto flatTableDto, int numberOfGuests, DateTime reservationDate, ReservationHours reservationHours);
    }
}