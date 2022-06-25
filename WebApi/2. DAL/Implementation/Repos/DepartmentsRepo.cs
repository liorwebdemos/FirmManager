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

        public DepartmentModel? GetByIdWithWorkers(int entityId)
        {
            // not ideal but works: https://stackoverflow.com/a/7348694
            return _mainContext.Set<DepartmentModel>()
                .Include(t => t.Workers)
                .FirstOrDefault(t => t.Id == entityId);
        }

        public IQueryable<DepartmentModel> GetAllWithWorkers()
        {
            return _mainContext.Set<DepartmentModel>()
                .Include(t => t.Workers)
                .AsNoTracking();
        }
    }
}
