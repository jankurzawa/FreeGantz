namespace FreeGantz.Data.Context
{
    public class FreeGantzContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public FreeGantzContext(DbContextOptions<FreeGantzContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=FreeGantz;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reservation>()
                .HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TableId);

            builder.SeedTables();
            builder.SeedAdminCredential();
        }
    }
}