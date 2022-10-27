namespace FreeGantz.Data.DAO
{
    public class TableRepository : ITableRepository
    {
        private readonly FreeGantzContext _freeGantzContext;
        public TableRepository(FreeGantzContext freeGantzContext) 
            => _freeGantzContext = freeGantzContext;
        public void AddNewTable(Table table)
        {
            _freeGantzContext.Tables.Add(table);
            Save();
        }
        private void Save() 
            => _freeGantzContext.SaveChanges();
    }
}
