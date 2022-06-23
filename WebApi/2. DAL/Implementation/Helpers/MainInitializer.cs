using WebApi.Models;
using WebApi.DAL.Implementation.Contexts;

namespace WebApi.DAL.Implementation.Initializers
{
    // https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding#custom-initialization-logic, https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#initialize-db-with-test-data
    public static class MainInitializer
    {
        public static void Initialize(this MainContext mainContext)
        {
            // note: we're not running "mainContext.Database.EnsureCreated()" since we're already using "Database.Migrate()";

            if (mainContext.Departments.Any() || mainContext.Workers.Any()) // DB has already been seeded
            {
                return; 
            }

            mainContext.Add(GetDepartmentSeed());
            mainContext.AddRange(GetWorkersSeed());
            mainContext.SaveChanges();
        }

        public static DepartmentModel GetDepartmentSeed() // non-explicit return type to allow future changes with ease
        {
            return new DepartmentModel()
            {
                Title = "Superheros & Villains",
                Description = "Some clever description.",
                IsActive = true
            };
        }

        public static IEnumerable<WorkerModel> GetWorkersSeed()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            return new List<WorkerModel>()
            {
                new WorkerModel()
                {
                    IsraeliIdentityNumber = 123456789,
                    FirstName = "Wonder",
                    LastName = "Woman",
                    Gender = Gender.Female,
                    JobStartDate = now,
                    JobEndDate = now.AddYears(2),
                    JobDescription = "Superhero",
                    DepartmentId = 1
                },
                new WorkerModel()
                {
                    IsraeliIdentityNumber = 987654321,
                    FirstName = "Thanos",
                    LastName = "",
                    Gender = Gender.Male,
                    JobStartDate = now,
                    JobEndDate = now.AddYears(5),
                    JobDescription = "Villain",
                    DepartmentId = 1
                }
            };
        }
    }
}