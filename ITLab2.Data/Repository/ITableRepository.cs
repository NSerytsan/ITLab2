using ITLab2.Data.Model;

namespace ITLab2.Data.Repository
{
    internal interface ITableRepository
    {
        public IEnumerable<Table> Get();
        public Table? Get(int id);
        public void Add(Table table);
        public void Update(Table table);
        public void Delete(Table table);
    }
}