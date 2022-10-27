namespace FreeGantz.Models
{
    public class AvailableTableModelFactory : IAvailableTableModelFactory
    {
        public AvailableTableModel create(FlatTableDto flatTableDto, int numberOfGuests, DateTime reservationDate, ReservationHours reservationHours)
        {
            int tableSize = flatTableDto.TableSize;
            string description = flatTableDto.Description;
            Guid tableId = flatTableDto.TableId;

            AvailableTableModel model = new AvailableTableModel()
            {
                Email = "",
                Name = "",
                NumberOfGuest = numberOfGuests,
                ReservationDate = reservationDate,
                ReservationHours = reservationHours,
                Description = description,
                TableId = tableId,
                TableSize = tableSize
            };
            return model;
        }
    }
}

