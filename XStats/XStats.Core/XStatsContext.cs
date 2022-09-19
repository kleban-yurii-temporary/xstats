using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace XStats.Core
{
    public class XStatsContext : IdentityDbContext<User>
    {
        public XStatsContext(DbContextOptions<XStatsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            base.OnModelCreating(builder);
        }

        public DbSet<DailyLosses> DailyLosses { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
    }
}