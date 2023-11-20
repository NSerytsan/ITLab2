using ITLab2.Data.Model;

namespace ITLab2.Data.Repository
{
    public interface IDatabaseRepository
    {
        public IEnumerable<Database> GetAll();
        public Database? Get(int id);
        public void Add(Database database);
        public void Update(Database database);
        public void Delete(int id);
    }
}