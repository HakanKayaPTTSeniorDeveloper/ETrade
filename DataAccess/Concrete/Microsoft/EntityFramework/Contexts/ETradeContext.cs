using Entity.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Microsoft.EntityFramework.Contexts
{
    public class ETradeContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ETrade;Uid=ETradeUser;Pwd=1");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
