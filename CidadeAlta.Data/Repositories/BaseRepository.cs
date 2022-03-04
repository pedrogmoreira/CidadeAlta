using CidadeAlta.Data.Context;
using CidadeAlta.Domain.Entities;
using CidadeAlta.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CidadeAlta.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly CidadeAltaContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(CidadeAltaContext database)
        {
            _context = database;
            _dbSet = database.Set<TEntity>();
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        /// <summary>
        /// Finds an entity with the given primary key value.
        /// </summary>
        /// <param name="id">The value of the primary key for the entity to be found.</param>
        public virtual TEntity? Find(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Inserts a new entity synchronously. 
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified entity synchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the entity by the specified primary key synchronously.
        /// </summary>
        /// <param name="id">The primary key value.</param>
        public virtual void Delete(int id)
        {
            TEntity? entity = Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }           
        }
    }
}
