namespace FreeGantz.Data.Seeders
{
    public static class AdminCredentialsSeeder
    {
        public static void SeedAdminCredential(this ModelBuilder modelBuilder)
        {
            List<Credentials> credentials = new List<Credentials>()
            {
                new Credentials("admin", "admin", "admin"),
            };
            modelBuilder.Entity<Credentials>()
                .HasData(credentials);
        }
    }
}
