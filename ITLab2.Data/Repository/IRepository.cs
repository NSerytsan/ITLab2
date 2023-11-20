using ITLab2.Data.Model;

namespace ITLab2.Data.Repository
{
    internal interface IRepository
    {
        public IEnumerable<Database> GetAll();
    }
}
