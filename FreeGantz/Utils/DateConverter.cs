namespace FreeGantz.Utils
{
    public class DateConverter
    {
        public DateTime ParseDateFromCalendar(string dateFromCallendar)
        {
            var elementOfDate = dateFromCallendar.Remove(0, dateFromCallendar.IndexOf(' ') + 1).Split("/");
            int year, month, day;
            try
            {
                year = int.Parse(elementOfDate[2]);
                month = int.Parse(elementOfDate[0]);
                day = int.Parse(elementOfDate[1]);
                return new DateTime(year, month, day);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
        public ReservationHours ParseHour(string hourFromForm)
            => (ReservationHours)int.Parse(hourFromForm.Remove
                (hourFromForm.IndexOf(':'), (hourFromForm.Length) - hourFromForm.IndexOf(':')));
    }
}
