using Microsoft.EntityFrameworkCore;
using PopDb.Models;

namespace WebApi.DAL.Contexts
{
    public class MainContext : DbContext
    {
        //public readonly IConfiguration Configuration;

        public MainContext(DbContextOptions<MainContext> options) : base(options) //IConfiguration configuration
        {
            //Configuration = configuration;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        //}

        public DbSet<DepartmentModel>? Departments { get; set; }
        public DbSet<WorkerModel>? Workers { get; set; }
    }
}

