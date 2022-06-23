using Microsoft.EntityFrameworkCore;
using PopDb.Models;

namespace WebApi.DAL.Implementation.Contexts
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
                .OnDelete(DeleteBehavior.SetNull) // cascading behavior (https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete#configuring-cascading-behaviors)
                .HasForeignKey(t => t.DepartmentId); // optional relationship (https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#required-and-optional-relationships)

            //modelBuilder.ApplyConfiguration(new TrackedModelConfiguration<DepartmentModel>()); // useful but not actually needed for this specific use case we're overriding SaveChanges(). also, in theory, we'd automatically get all the classes that derive from TrackedModel instead of having to list the one by one

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return OnSaveHandleTrackedModels();
        }

        // https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
        private int OnSaveHandleTrackedModels()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is TrackedModel
                       && (e.State == EntityState.Added || e.State == EntityState.Modified));

            if (!entries.Any()) return base.SaveChanges();

            var remoteIpAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var now = DateTimeOffset.Now;

            foreach (var entityEntry in entries)
            {
                ((TrackedModel)entityEntry.Entity).UpdatedDate = now;
                ((TrackedModel)entityEntry.Entity).UpdatedUserIp = remoteIpAddress;

                if (entityEntry.State == EntityState.Added)
                {
                    ((TrackedModel)entityEntry.Entity).CreatedDate = now;
                    ((TrackedModel)entityEntry.Entity).CreatedUserIp = remoteIpAddress;
                }
            }

            return base.SaveChanges();
        }
    }
}

