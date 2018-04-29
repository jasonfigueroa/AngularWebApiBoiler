using AngularWebApiBoiler.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebApiBoiler.Data
{
    public class AngularWebApiBoilerContext : DbContext
    {
        public AngularWebApiBoilerContext(DbContextOptions<AngularWebApiBoilerContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
