namespace FreeGantz.Data.Entries
{
    public class Credentials
    {
        [Key]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Credentials()
            => Id = Guid.NewGuid();

        public Credentials(string login, string password, string email)
        {
            Id= Guid.NewGuid();
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
