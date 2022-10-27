namespace FreeGantz.Data.Entries
{
    public class Table
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Table()
        {
            Id = Guid.NewGuid();
            Reservations = new List<Reservation>();
        }
        public Table(int size, string description)
        {
            Id= Guid.NewGuid();
            Size = size;
            Description = description;
            Reservations = new List<Reservation>();
        }
    }
}
