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

            mainContext.AddRange(GetDepartmentSeed());
            mainContext.AddRange(GetWorkersSeed());
            mainContext.SaveChanges();
        }

        public static List<DepartmentModel> GetDepartmentSeed()
        {
            return new List<DepartmentModel>()
            {
                new()
                {
                    Title = "Superheros",
                    Description = "Somekind of clever description.",
                    IsActive = true
                },
                new()
                {
                    Title = "Villains",
                    Description = "Another clever description.",
                    IsActive = true
                },
                new()
                {
                    Title = "Regular Folks",
                    Description = "Yet another clever description.",
                    IsActive = true
                }
            };
        }

        public static IEnumerable<WorkerModel> GetWorkersSeed()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            return new List<WorkerModel>()
            {
                new()
                {
                    IsraeliIdentityNumber = 123456789,
                    FirstName = "Wonder",
                    LastName = "Woman",
                    Gender = Gender.Female,
                    JobStartDate = now,
                    JobEndDate = now.AddYears(2),
                    JobDescription = "Saving earth",
                    DepartmentId = 1
                },
                new()
                {
                    IsraeliIdentityNumber = 123456789,
                    FirstName = "Spider",
                    LastName = "Man",
                    Gender = Gender.Male,
                    JobStartDate = null,
                    JobEndDate = null,
                    JobDescription = "Your friendly neighborhood superhero",
                    DepartmentId = 1
                },
                new()
                {
                    IsraeliIdentityNumber = 987654321,
                    FirstName = "Thanos",
                    LastName = "",
                    Gender = Gender.Male,
                    JobStartDate = now,
                    JobEndDate = now.AddYears(5),
                    JobDescription = null,
                    DepartmentId = 2
                },
                new()
                {
                    IsraeliIdentityNumber = 987654321,
                    FirstName = "Bane",
                    LastName = "",
                    Gender = Gender.Male,
                    JobStartDate = now,
                    JobEndDate = now.AddYears(5),
                    JobDescription = null,
                    DepartmentId = 2
                },
                new()
                {
                    IsraeliIdentityNumber = null,
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = Gender.Male,
                    JobStartDate = now,
                    JobEndDate = now.AddYears(5),
                    JobDescription = null,
                    DepartmentId = 3
                },
                new()
                {
                    IsraeliIdentityNumber = null,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Gender = Gender.Female,
                    JobStartDate = now,
                    JobEndDate = now.AddYears(5),
                    JobDescription = null,
                    DepartmentId = 3
                }
            };
        }
    }
}