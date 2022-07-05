using Application.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EfEntityRepositoryBase<T, TContext> : IEntityRepository<T>
     where T : class, IEntity
     where TContext : DbContext
    {
        protected readonly TContext _context;
        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            entity.Inserted += Entity_Inserted;
            return _context.Add(entity).Entity;
        }

        private bool Entity_Inserted(IEntity entity)
        {
            return true;//loglama yapılcak:D
        }

        public T Update(T entity)
        {
            entity.Updated += Entity_Updated; ;
            _context.Update(entity);
            return entity;
        }

        private bool Entity_Updated(IEntity entity)
        {
            return true;//loglama yapılcak:D
        }

        public void Delete(T entity)
        {
            entity.Deleted += Entity_Deleted;
            _context.Remove(entity);
        }

        private bool Entity_Deleted(IEntity entity)
        {
            return true;//loglama yapılcak:D
        }

        public Task<int> Execute(FormattableString interpolatedQueryString)
        {
            return null; //_context.Database.ExecuteSqlInterpolatedAsync(interpolatedQueryString);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AsQueryable().FirstOrDefaultAsync(expression);
        }
        public int GetCount(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
                return _context.Set<T>().Count();
            else
                return _context.Set<T>().Count(expression);
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
                return await _context.Set<T>().CountAsync();
            else
                return await _context.Set<T>().CountAsync(expression);
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _context.Set<T>().AsNoTracking() : _context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _context.Set<T>().ToListAsync() :
                 await _context.Set<T>().Where(expression).ToListAsync();
        }

        public TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null)
        {
            var result = default(TResult);
            try
            {
                if (_context.Database.ProviderName.EndsWith("InMemory"))
                {
                    result = action();
                    SaveChanges();
                }
                else
                {
                    using (var tx = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            result = action();
                            SaveChanges();
                            tx.Commit();
                        }
                        catch (Exception)
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                successAction?.Invoke();
            }
            catch (Exception ex)
            {
                if (exceptionAction == null)
                    throw;
                else
                    exceptionAction(ex);
            }
            return result;
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
