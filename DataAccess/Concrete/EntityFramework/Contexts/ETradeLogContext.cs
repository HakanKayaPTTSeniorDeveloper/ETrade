using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entities.Concrete.Entities;
using Core.Utilities.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ETradeLogContext:DbContext
    {

        private IConfiguration _configuration;
        public ETradeLogContext()
        {
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ETradeLog"));
        }

        public DbSet<ApiLog> ApiLogs { get; set; }         
            
        public DbSet<UILog> UILogs { get; set; }

    }
    
}
