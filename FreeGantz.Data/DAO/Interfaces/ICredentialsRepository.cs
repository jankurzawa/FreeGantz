namespace FreeGantz.Data.DAO.Interfaces
{
    public interface ICredentialsRepository
    {
        public bool CheckIfCredenrialsExsist(string email, string password);
    }
}
