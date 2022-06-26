using Microsoft.EntityFrameworkCore;
using WebApi.DAL.Contracts;
using WebApi.DAL.Implementation.Contexts;
using WebApi.Models;

namespace WebApi.DAL.Repos.Implementation
{
    // concept: https://stackoverflow.com/a/1624209
    public class DepartmentsRepo : GenericRepo, IDepartmentsRepo
    {
        private readonly MainContext _mainContext;

        public DepartmentsRepo(MainContext mainContext) : base(mainContext) {
            _mainContext = mainContext;
        }

        public DepartmentModel? GetByIdWithWorkers(int departmentId)
        {
            // not ideal but works: https://stackoverflow.com/a/7348694
            return _mainContext.Set<DepartmentModel>()
                .Include(t => t.Workers)
                .FirstOrDefault(t => t.Id == departmentId);
        }

        public IQueryable<DepartmentModel> GetAllWithWorkers()
        {
            return _mainContext.Set<DepartmentModel>()
                .Include(t => t.Workers)
                .AsNoTracking();
        }

        public new DepartmentModel Delete<TEntity>(int departmentId)
        {
            //if we just use the generic repo's delete function for the department,
            //without attaching its workers too, it won't cascade (and the delete will actually fail because it'll collide with the FK in the DB)

            DepartmentModel? toDelete = GetByIdWithWorkers(departmentId);
            Console.WriteLine(_mainContext.ChangeTracker.DebugView.LongView);
            if (toDelete == default)
            {
                throw new ArgumentException();
            }
            return _mainContext.Remove(toDelete).Entity;
        }
    }
}
