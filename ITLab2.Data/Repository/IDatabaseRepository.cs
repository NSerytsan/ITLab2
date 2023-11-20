using ITLab2.Data.Model;

namespace ITLab2.Data.Repository
{
    internal interface IDatabaseRepository
    {
        public IEnumerable<Database> Get();
        public Database? Get(int id);
        public void Add(Database database);
        public void Update(Database database);
        public void Delete(int id);
    }
}