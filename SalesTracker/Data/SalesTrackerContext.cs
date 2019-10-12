using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Models
{
    public class SalesTrackerContext : DbContext
    {
        public SalesTrackerContext (DbContextOptions<SalesTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<SalesTracker.Models.Department> Department { get; set; }

        public DbSet<SalesTracker.Models.SalesPerson> SalesPerson { get; set; }

        public DbSet<SalesTracker.Models.AwardNotice> AwardNotice { get; set; }

        public DbSet<SalesTracker.Models.Sale> Sale { get; set; }

        public DbSet<SalesTracker.Models.StoreItem> StoreItem { get; set; }
    }
}
