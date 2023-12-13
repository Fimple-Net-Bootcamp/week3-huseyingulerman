using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.Interfaces;
using week3_huseyingulerman.Core.Repositories;
using System.Linq.Expressions;
using System.Transactions;
using week3_huseyingulerman.Core.Enums;

namespace week3_huseyingulerman.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context=context;
            _dbSet=_context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (T entity in entities)
                {
                    await _dbSet.AddRangeAsync(entity);
                }
                scope.Complete();
            }
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetAllActive()
        {
            return _dbSet.Where(x => x.IsActive).AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public bool Remove(T entity)
        {
            try
            {
                entity.IsActive=false;
                entity.Status=Status.Deleted;
                var a = _dbSet.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (T entity in entities)
                    {
                        entity.IsActive=false;
                        Update(entity);
                    }
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
