using Microsoft.EntityFrameworkCore;
using PopDb.Models;

namespace WebApi.DAL.Contexts
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public DbSet<DepartmentModel> Departments { get; set; } = null!; // "null!" as suggested @ https://stackoverflow.com/a/57343485
        public DbSet<WorkerModel> Workers { get; set; } = null!;

        // seed data (note: there's a cleaner way, see https://code-maze.com/migrations-and-seed-data-efcore/#betterwayapplyingconfiguration)
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    DateTimeOffset now = DateTimeOffset.Now;
        //    modelBuilder.Entity<DepartmentModel>()
        //        .HasData(
        //            new DepartmentModel
        //            {
        //                Id = -1,
        //                Title = "Superheros & Villains",
        //                Description = "Some clever description.",
        //                IsActive = true,
        //                InsertDate = now,
        //                InsertUserIp = "0.0.0.0",
        //                LastUpdateDate = now,
        //                LastUpdateUserIp = "0.0.0.0",
        //                //Workers = new List<WorkerModel>()
        //                //{
        //                //    new WorkerModel()
        //                //    {
        //                //        Id = -2,
        //                //        IsraeliIdentityNumber = 123456789,
        //                //        FirstName = "Wonder",
        //                //        LastName = "Woman",
        //                //        Gender = Gender.Female,
        //                //        JobStartDate = now,
        //                //        JobEndDate = now.AddYears(2),
        //                //        JobDescription = "Superhero"
        //                //    },
        //                //    new WorkerModel()
        //                //    {
        //                //        Id = -1,
        //                //        IsraeliIdentityNumber = 987654321,
        //                //        FirstName = "Thanos",
        //                //        LastName = "",
        //                //        Gender = Gender.Male,
        //                //        JobStartDate = now,
        //                //        JobEndDate = now.AddYears(5),
        //                //        JobDescription = "Villain"
        //                //    }
        //                //}
        //            }
        //        );
        //    modelBuilder.Entity<WorkerModel>()
        //        .HasData(
        //            new WorkerModel()
        //            {
        //                Id = -2,
        //                IsraeliIdentityNumber = 123456789,
        //                FirstName = "Wonder",
        //                LastName = "Woman",
        //                Gender = Gender.Female,
        //                JobStartDate = now,
        //                JobEndDate = now.AddYears(2),
        //                JobDescription = "Superhero"
        //            },
        //            new WorkerModel()
        //            {
        //                Id = -1,
        //                IsraeliIdentityNumber = 987654321,
        //                FirstName = "Thanos",
        //                LastName = "",
        //                Gender = Gender.Male,
        //                JobStartDate = now,
        //                JobEndDate = now.AddYears(5),
        //                JobDescription = "Villain"
        //            }
        //        );
        //}
    }
}

