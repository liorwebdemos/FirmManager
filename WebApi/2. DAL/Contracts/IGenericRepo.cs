using WebApi.Models;

namespace WebApi.DAL.Contracts
{
    public interface IGenericRepo
    {
        void SaveChanges();

        TEntity? GetById<TEntity>(int entityId) where TEntity : class, IDbEntity; //param should be `params object[] entityKeyValues` if we want to be even more generic

        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IDbEntity;

        TEntity Add<TEntity>(TEntity entity) where TEntity : class, IDbEntity;

        TEntity Delete<TEntity>(int entityId) where TEntity : class, IDbEntity; //param should be `params object[] entityKeyValues` if we want to be even more generic
    }
}
