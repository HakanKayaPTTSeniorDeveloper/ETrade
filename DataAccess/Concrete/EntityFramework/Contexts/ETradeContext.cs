using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Core.Entities.Concrete.Entities;
using Core.Utilities.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ETradeContext : DbContext
    {
        private IConfiguration _configuration;
        public ETradeContext()
        {
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ETrade"));
        }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

