using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.DAL.Repositories
{
    public class Repository<T> where T : class
    {
        protected readonly GameZoneDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(GameZoneDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
    }
}
