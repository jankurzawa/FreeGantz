namespace FreeGantz.Data.DAO.Interfaces
{
    public interface IReservationRepository
    {
        public Table GetTheLittlestAvailableTable(int numberOfGuests, DateTime day, ReservationHours reservationHour);
        public void AddReservation(DateTime day, ReservationHours reservationHour, string name, string customerEmail, Guid tableId);
        public List<Reservation> GetTodaysReservations();
        public Reservation GetReservationById(Guid id);
        public void Delete(Reservation reservation);
    }
}
