using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MariaWebApp.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        private readonly ApplicationDbContext _context;

        public EntityBaseRepository( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == Id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            var result = await _context.Set<T>().ToListAsync();


            return result;
        }

        public  async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperities)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperities.Aggregate(query, (current, includeProperities) => current.Include(includeProperities));
            return await query.ToListAsync();
        }

        public  async Task<T> GetByIdAsync(int Id)
        {

            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == Id);
            return result;
        }


        public async Task UpdateAsync(int Id, T entity)
        {
            EntityEntry entityEntry =_context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }


        
    }
}
