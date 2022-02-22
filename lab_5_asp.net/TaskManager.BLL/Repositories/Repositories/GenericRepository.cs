using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.DAL;

namespace TaskManager.BLL.Repositories.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ApplicationContext _db;
        private readonly DbSet<TEntity> _entity;

        public GenericRepository(ApplicationContext context)
        {
            _db = context;
            _entity = context.Set<TEntity>();
        }

        public TEntity GetById(TKey id)
        {
            return _entity.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entity;
        }

        public void Create(TEntity entity)
        {
            _entity.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _entity.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _entity.Remove(entity);
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}