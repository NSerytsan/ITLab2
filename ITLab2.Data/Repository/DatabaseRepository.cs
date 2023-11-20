using ITLab2.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ITLab2.Data.Repository
{
    public class DatabaseRepository(DatabaseStorage storage) : IDatabaseRepository
    {
        private readonly DatabaseStorage _storage = storage;

        public IEnumerable<Database> GetAll()
        {
            return _storage.Databases.AsNoTracking().ToList();
        }

        public Database? Get(int id)
        {
            return _storage.Databases.Find(id);
        }

        public void Add(Database database)
        {
            _storage.Databases.Add(database);
            _storage.SaveChanges();
        }

        public void Update(Database database)
        {
            _storage.Update(database);
            _storage.SaveChanges();
        }

        public void Delete(int id)
        {
            if (_storage.Databases.Find(id) is Database database)
            {
                _storage.Databases.Remove(database);
                _storage.SaveChanges();
            }
        }
    }
}
