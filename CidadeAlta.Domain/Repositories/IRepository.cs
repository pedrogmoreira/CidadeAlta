using CidadeAlta.Domain.Entities;

namespace CidadeAlta.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(string[] includes = null);
        TEntity? Find(int id, string[] includes = null);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
