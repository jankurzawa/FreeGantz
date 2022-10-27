namespace FreeGantz.Data.DAO
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly FreeGantzContext _freeGantzContext;
        public ReservationRepository(FreeGantzContext freeGantzContext) 
            => _freeGantzContext = freeGantzContext;
        public Table? GetTheLittlestAvailableTable(int numberOfGuests, DateTime day, ReservationHours reservationHour)
        {
            var reservationsForGivenDayAndReservationHour = _freeGantzContext.Reservations
                .Where(r => r.Day == day && r.ReservationHour == reservationHour && r.Table.Size >= numberOfGuests)
                .OrderBy(r => r.Table.Size).ToList();
            if (reservationsForGivenDayAndReservationHour.Count == GetNumberOfTablesWithEnoughtSize(numberOfGuests))
                return null;
            else
            {
                var tablesWithEnughtSize = _freeGantzContext.Tables.Where(t => t.Size >= numberOfGuests).OrderBy(t => t.Size).ToList();
                foreach (var table in tablesWithEnughtSize)
                {
                    bool isCurrentTableExistInReservations = false;
                    foreach (var reservation in reservationsForGivenDayAndReservationHour)
                    {
                        if (reservation.TableId == table.Id) isCurrentTableExistInReservations = true;
                    }
                    if (!isCurrentTableExistInReservations) return table;
                }
            }
            return null;
        }
        public void AddReservation(DateTime day, ReservationHours reservationHour, string name, string customerEmail, Guid tableId)
        {
            _freeGantzContext.Reservations.Add(new Reservation(day, reservationHour, name, customerEmail, _freeGantzContext.Tables.FirstOrDefault(table=>table.Id == tableId).Id));
            _freeGantzContext.SaveChanges();
        }
        private int GetNumberOfTablesWithEnoughtSize(int numberOfGuests)
            => _freeGantzContext.Tables.Where(t => t.Size >= numberOfGuests).Count();
        public List<Reservation> GetTodaysReservations()
            => _freeGantzContext
            .Reservations
            .Include("Table").Where(r=>r.Day.Year == DateTime.Now.Year && r.Day.Month == DateTime.Now.Month
            && r.Day.Day == DateTime.Now.Day).ToList();
        public Reservation GetReservationById(Guid Id) 
            => _freeGantzContext.Reservations.Where(t => t.Id == Id).FirstOrDefault();
        public void Delete(Reservation reservation)
        {
            _freeGantzContext.Reservations.Remove(reservation);
            _freeGantzContext.SaveChanges();
        }
    }
}
