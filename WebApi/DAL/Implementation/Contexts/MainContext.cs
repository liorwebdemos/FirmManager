using Microsoft.EntityFrameworkCore;
using PopDb.Models;

namespace WebApi.DAL.Contexts
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public DbSet<DepartmentModel> Departments { get; set; } = null!; // "null!" as suggested @ https://stackoverflow.com/a/57343485
        public DbSet<WorkerModel> Workers { get; set; } = null!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>()
        //        .ToTable("Student");
        //    modelBuilder.Entity<Student>()
        //        .Property(s => s.Age)
        //        .IsRequired(false);
        //    modelBuilder.Entity<Student>()
        //        .Property(s => s.IsRegularStudent)
        //        .HasDefaultValue(true);
        //    modelBuilder.Entity<Student>()
        //        .HasData(
        //            new Student
        //            {
        //                Id = Guid.NewGuid(),
        //                Name = "John Doe",
        //                Age = 30
        //            },
        //            new Student
        //            {
        //                Id = Guid.NewGuid(),
        //                Name = "Jane Doe",
        //                Age = 25
        //            }
        //        );
        //}
    }
}

