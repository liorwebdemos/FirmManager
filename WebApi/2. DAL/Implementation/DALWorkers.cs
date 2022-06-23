//using Microsoft.EntityFrameworkCore;
//using WebApi.DAL.Contracts;
//using WebApi.DAL.Implementation.Contexts;
//using WebApi.Models;

//namespace WebApi.DAL.Implementation
//{
//    public class DALWorkers : IDALWorkers
//    {
//        private readonly MainContext _mainContext;

//        public DALWorkers(MainContext mainContext)
//        {
//            _mainContext = mainContext;
//        }

//        public void SaveChanges()
//        {
//            _mainContext.SaveChanges();
//        }

//        public WorkerModel? GetById(int workerId)
//        {
//            return _mainContext.Workers.Find(workerId);
//        }

//        public IQueryable<WorkerModel> GetAll()
//        {
//            return _mainContext.Workers.AsNoTracking(); // tracking is "expensive" (resources wise). if we need to, we can also create GetAllTracked
//        }

//        public WorkerModel Add(WorkerModel worker)
//        {
//            return _mainContext.Workers.Add(worker).Entity;
//        }

//        public WorkerModel Delete(int workerId)
//        {
//            WorkerModel? toRemove = GetById(workerId);
//            if (toRemove == null)
//            {
//                throw new ArgumentException();
//            }
//            return _mainContext.Workers.Remove(toRemove).Entity;
//        }
//    }
//}
