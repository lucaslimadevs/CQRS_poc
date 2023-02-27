using CQRS_poc.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CQRS_poc.Infra.Sqlite.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
                    
    }
}
