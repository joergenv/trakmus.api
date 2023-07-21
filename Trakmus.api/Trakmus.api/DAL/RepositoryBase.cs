using System.Linq.Expressions;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Trakmus.api.DAL
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void Delete(T entity);
    }


    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TrakMusContext RepositoryContext { get; set; }

        public RepositoryBase (TrakMusContext context)
        {
            this.RepositoryContext = context;
        }

        public IQueryable<T> FindAll()
        {
            try
            {
                return this.RepositoryContext.Set<T>();
            }
            catch(Exception ex)
            {
                throw new Exception($"kunne ikke hente entititer: {ex.Message}");
            }
            
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
                throw new Exception("Entiteten er null");
            try
            {
                await RepositoryContext.AddAsync(entity);
                await RepositoryContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new Exception("Entiteten er null");

            try
            {
                RepositoryContext.Update(entity);
                await RepositoryContext.SaveChangesAsync();
                return entity;
            }

            catch (Exception ex)
            {
                throw new Exception($"Kunne ikke opdatere entitet: {ex.Message}");
            }
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

    }
}
