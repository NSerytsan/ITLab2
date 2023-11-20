﻿using ITLab2.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ITLab2.Data.Storage
{
    public class DatabaseStorage(DbContextOptions<DatabaseStorage> options) : DbContext(options)
    {
        public DbSet<Database> Databases => Set<Database>();
        public DbSet<Table> Tables => Set<Table>();
    }
}