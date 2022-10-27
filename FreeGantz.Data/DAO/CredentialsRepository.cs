namespace FreeGantz.Data.DAO
{
    public class CredentialsRepository : ICredentialsRepository
    {
        private readonly FreeGantzContext _freeGantzContext;
        public CredentialsRepository(FreeGantzContext freeGantzContext) => _freeGantzContext = freeGantzContext;
        public bool CheckIfCredenrialsExsist(string email, string password) 
            => _freeGantzContext.Credentials.Where(x => x.Email == email && x.Password == password).Any();
    }
}
