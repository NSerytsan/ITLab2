using ITLab2.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ITLab2.Data.Repository
{
    public class DatabaseStorage : DbContext
    {
        public DbSet<Database> Databases => Set<Database>();
        public DbSet<Table> Tables => Set<Table>();
        public DbSet<Column> Columns => Set<Column>();
        public DbSet<Row> Rows => Set<Row>();

        public DatabaseStorage(DbContextOptions<DatabaseStorage> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
