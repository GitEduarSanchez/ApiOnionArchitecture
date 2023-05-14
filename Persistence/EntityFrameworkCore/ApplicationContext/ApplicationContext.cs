namespace Persistence.EntityFrameworkCore.ApplicationContext
{
    using Application.Interfaces;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using System.Threading.Tasks;
    using System.Threading;
    using Domain.Common;
    using System.Reflection;

    public class ApplicationContext : DbContext
    {
        private readonly IDateTimeService dateTime;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IDateTimeService dateTime ) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.dateTime = dateTime;
        }
        public DbSet<Customer> Customres { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = this.dateTime.NowUtc;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = this.dateTime.NowUtc;
                        break;

                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
