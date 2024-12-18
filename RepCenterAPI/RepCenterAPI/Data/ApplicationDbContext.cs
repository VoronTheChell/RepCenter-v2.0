using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MilkDeliveryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Studet> Students { get; set; }
        public DbSet<Pridment> Pridments { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
