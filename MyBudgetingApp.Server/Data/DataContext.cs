using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Transactions;

namespace MyBudgetingApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Wallet>? Wallet { get; set; }
        //public DbSet<Transaction>? Txns { get; set; }
        //public DbSet<Users>? Users { get; set; }
        //public DbSet<EventLog>? EventLog { get; set; }
        //public DbSet<Budget>? Budget { get; set; }
        //public DbSet<Permission>? Permission { get; set; }
    }
}
