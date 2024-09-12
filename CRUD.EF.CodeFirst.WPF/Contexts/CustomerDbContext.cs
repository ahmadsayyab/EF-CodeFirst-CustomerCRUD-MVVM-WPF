using CRUD.EF.CodeFirst.WPF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.EF.CodeFirst.WPF.Contexts
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDbContext() : base("CustomerDbContext")
        {
        }
    }
}
