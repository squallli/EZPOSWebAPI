using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZPOSWebAPI.Models
{
    public class POSContext:DbContext
    {
        public POSContext(DbContextOptions options) : base(options) { }

        public DbSet<Inventory> invs { set; get; }
        public DbSet<CataLog> cataLog { set; get; }
    }
}
