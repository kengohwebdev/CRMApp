using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Antra.CRMApp.Infrastructure.Data
{
    public class CrmDbContext:IdentityDbContext<ApplicationUser>
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> option):base(option)
        {

        }

        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        

    }
}
