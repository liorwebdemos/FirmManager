using PopDb.Models;
using WebApi.DAL.Contexts;

namespace WebApi.DAL.Initializers
{
    // https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding#custom-initialization-logic, https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#initialize-db-with-test-data
    public static class MainInitializer
    {
        public static void Initialize(this MainContext mainContext)
        {
            // note: we shouldn't run "mainContext.Database.EnsureCreated()" this if we're already using Database.Migrate();

            if (mainContext.Departments.Any() || mainContext.Workers.Any()) // DB has already been seeded
            {
                return; 
            }

            var seedData = GetSeedData();
            mainContext.Add(seedData);
            mainContext.SaveChanges();
        }

        public static dynamic GetSeedData() // non-explicit return type to allow future changes with ease
        {
            DateTimeOffset now = DateTimeOffset.Now;
            List<WorkerModel> workers = new()
            {
                new WorkerModel()
                {
                    IsraeliIdentityNumber = 123456789,
                    FirstName = "Wonder",
                    LastName = "Woman",
                    Gender = Gender.Female,
                    JobStartDate = now,
                    JobEndDate = now.AddYears(2),
                    JobDescription = "Superhero"
                },
                new WorkerModel()
                {
                    IsraeliIdentityNumber = 987654321,
                    FirstName = "Thanos",
                    LastName = "",
                    Gender = Gender.Male,
                    JobStartDate = now,
                    JobEndDate = now.AddYears(5),
                    JobDescription = "Villain"
                }
            };
            return new DepartmentModel()
            {
                Title = "Superheros & Villains",
                Description = "Some clever description.",
                IsActive = true,
                InsertDate = now,
                InsertUserIp = "0.0.0.0",
                LastUpdateDate = now,
                LastUpdateUserIp = "0.0.0.0",
                Workers = workers
            };
        }
    }
}