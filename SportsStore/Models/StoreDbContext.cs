using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
