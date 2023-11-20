using ITLab2.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ITLab2.Data.Repository
{
    public class DatabaseStorage(DbContextOptions<DatabaseStorage> options) : DbContext(options)
    {
        public DbSet<Database> Databases => Set<Data>();
        public DbSet<Table> Tables => Set<Table>();
    }
}
