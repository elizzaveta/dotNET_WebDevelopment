using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManager.BLL.Repositories.Interfaces;
using TaskManager.DAL;

namespace TaskManager.BLL.Repositories.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _db;
        private readonly DbSet<T> _entity;

        public GenericRepository(ApplicationContext context)
        {
            _db = context;
            _entity = context.Set<T>();
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToArray();
        }

        public void Create(T entity)
        {
            _entity.Add(entity);
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
            _db.SaveChanges();
        }
    }
}