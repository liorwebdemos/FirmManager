//using Microsoft.EntityFrameworkCore;
//using WebApi.DAL.Contracts;
//using WebApi.DAL.Implementation.Contexts;
//using WebApi.Models;

//namespace WebApi.DAL.Implementation
//{
//    public class DALDepartments : IDALDepartments
//    {
//        private readonly MainContext _mainContext;

//        public DALDepartments(MainContext mainContext)
//        {
//            _mainContext = mainContext;
//        }

//        public void SaveChanges()
//        {
//            _mainContext.SaveChanges();
//        }

//        public DepartmentModel? GetById(int departmentId)
//        {
//            return _mainContext.Departments.Find(departmentId);
//        }

//        public IQueryable<DepartmentModel> GetAll()
//        {
//            return _mainContext.Departments.AsNoTracking(); // tracking is "expensive" (resources wise). if we need to, we can also create GetAllTracked
//        }

//        public DepartmentModel Add(DepartmentModel department)
//        {
//            return _mainContext.Departments.Add(department).Entity;
//        }

//        public DepartmentModel Delete(int departmentId)
//        {
//            DepartmentModel? toRemove = GetById(departmentId);
//            if (toRemove == null)
//            {
//                throw new ArgumentException();
//            }
//            return _mainContext.Departments.Remove(toRemove).Entity;
//        }
//    }
//}
