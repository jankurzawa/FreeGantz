namespace FreeGantz.Data.Seeders
{
    public static class TablesSeeder
    {
        public static void SeedTables(this ModelBuilder modelBuilder)
        {
            List<Table> tables = new List<Table>()
            {
                new Table(1, "small table in front of the window"),
                new Table(2, "charming table perfect for couples"),
                new Table(3, "triangular table next to the toilet"),
                new Table(4, "A table at the entrance, provides an additional poking experience"),
                new Table(5, "A slightly hidden table for noisy groups"),
                new Table(6, "large outdoor table near the kitchen"),
                new Table(7, "a large table in the middle of the premises"),
                new Table(8, "special table in the basement")
            };

            modelBuilder.Entity<Table>()
                .HasData(tables);
        }
    }
}
