using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;
using WebApi.DAL.Contracts;
using WebApi.DAL.Implementation.Contexts;
using WebApi.Models;

namespace WebApi.DAL.Repos.Implementation
{
    public class GenericRepo : IGenericRepo
    {
        private readonly MainContext _mainContext;

        public GenericRepo(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public void SaveChanges()
        {
            _mainContext.SaveChanges();
        }

        public TEntity? GetById<TEntity>(int entityId) where TEntity : class, IDbEntity
        {
            return _mainContext.Set<TEntity>().Find(entityId);
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IDbEntity
        {
            return _mainContext.Set<TEntity>().AsNoTracking(); // tracking is "expensive" (resources wise). if we need to, we can also create GetAllTracked
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IDbEntity
        {
            return _mainContext.Set<TEntity>().Add(entity).Entity;
        }

        public TEntity Delete<TEntity>(int entityId) where TEntity : class, IDbEntity
        {
            TEntity? toRemove = GetById<TEntity>(entityId);
            if (toRemove == null)
            {
                throw new ArgumentException();
            }
            return _mainContext.Set<TEntity>().Remove(toRemove).Entity;
        }
    }
}
