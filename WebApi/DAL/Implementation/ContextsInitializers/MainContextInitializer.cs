//using Microsoft.EntityFrameworkCore;
//using PopDb.Models;
//using WebApi.DAL.Contexts;

//namespace WebApi.DAL.Initializers
//{
//    // TODO: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#initialize-db-with-test-data
//    public static class MainContextInitializer
//    {
//        public static void Initialize(MainContext mainContext)
//        {
//            mainContext.Database.EnsureCreated();

//            if (mainContext.Departments.Any() || mainContext.Workers.Any())
//            {
//                return; // DB has been seeded
//            }

//            var seedData = GetSeedData();
//            mainContext.Add(seedData);
//            mainContext.SaveChanges();
//        }

//        public static dynamic GetSeedData() // non-explicit return type to allow future changes with ease
//        {
//            DateTimeOffset now = new DateTimeOffset();
//            List<WorkerModel> workers = new()
//            {
//                new WorkerModel()
//                {
//                    IsraeliIdentityNumber = 123456789,
//                    FirstName = "Wonder",
//                    LastName = "Woman",
//                    Gender = Gender.Female,
//                    JobStartDate = now,
//                    JobEndDate = now.AddYears(2),
//                    JobDescription = "Superhero"
//                },
//                new WorkerModel()
//                {
//                    IsraeliIdentityNumber = 987654321,
//                    FirstName = "Thanos",
//                    LastName = "",
//                    Gender = Gender.Male,
//                    JobStartDate = now,
//                    JobEndDate = now.AddYears(5),
//                    JobDescription = "Villain"
//                }
//            };
//            return new DepartmentModel()
//            {
//                Title = "Superheros & Villains",
//                Description = "Some clever description.",
//                IsActive = true,
//                InsertDate = now,
//                InsertUserIp = "0.0.0.0",
//                LastUpdateDate = now,
//                LastUpdateUserIp = "0.0.0.0",
//                Workers = workers
//            };
//        }
//    }
//}