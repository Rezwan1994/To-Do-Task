using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Model
{
    public class ToDoDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public ToDoDbContext(string connectionString, string assemblyName)
        {
            _assemblyName = assemblyName;
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assemblyName));

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Task> Tasks { get; set; }

    }
    

}
