using Microsoft.EntityFrameworkCore;
using PopDb.Models;

namespace WebApi.DAL.Contexts
{
    public class MainContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MainContext(
            DbContextOptions<MainContext> options,
            IHttpContextAccessor httpContextAccessor
        ) : base(options) {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<DepartmentModel> Departments { get; set; } = null!; // "null!" as suggested @ https://stackoverflow.com/a/57343485
        public DbSet<WorkerModel> Workers { get; set; } = null!;

        // TODO: it'd be cleaner to separate these to external files, where we configure each entity's part in the builder on its own
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentModel>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<WorkerModel>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<WorkerModel>()
                .HasOne<DepartmentModel>()
                .WithMany()
                .HasForeignKey(t => t.DepartmentId); // optional relationship (https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#required-and-optional-relationships)

        }

        // automatically set some properties (https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx)
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is DateAndUserIpTracked
                       && (e.State == EntityState.Added || e.State == EntityState.Modified));

            if (!entries.Any()) return base.SaveChanges();

            var remoteIpAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var now = DateTimeOffset.Now;

            foreach (var entityEntry in entries)
            {
                ((DateAndUserIpTracked)entityEntry.Entity).UpdatedDate = now;
                ((DateAndUserIpTracked)entityEntry.Entity).UpdatedUserIp = remoteIpAddress;

                if (entityEntry.State == EntityState.Added)
                {
                    ((DateAndUserIpTracked)entityEntry.Entity).CreatedDate = now;
                    ((DateAndUserIpTracked)entityEntry.Entity).CreatedUserIp = remoteIpAddress;
                }
            }

            return base.SaveChanges();
        }
    }
}

