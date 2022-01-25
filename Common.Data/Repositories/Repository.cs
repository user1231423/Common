using Common.Data.Interfaces;
using Common.Pagination;
using Common.Pagination.Models;
using Data.Authentication.Database;
using Data.Authentication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly AuthenticationDbContext _context;

        /// <summary>
        /// Current entities (table)
        /// </summary>
        private readonly DbSet<T> _entities;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Repository(AuthenticationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException("Missing authentication context");
            _entities = context.Set<T>();
        }

        /// <summary>
        /// Get table
        /// </summary>
        public virtual IQueryable<T> Table { 
            get {
                    return _entities; 
            } 
        }

        /// <summary>
        /// List
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public async Task<List<T>> List(PaginationParams pagination)
        {
            return await _entities.PageBy(x => x.Id, pagination).ToListAsync();
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetById(int id)
        {
            return await _entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<int> Insert(T entity)
        {

            if (entity == null)
                throw new ArgumentNullException("Entity is null");

            _entities.Add(entity);

            try
            {
                await _context.SaveChangesAsync();
            }catch (Exception ex) {
                throw new ArgumentException("Problem while saving changes", ex);
            }

            return entity.Id;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<int> Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null");
            
            _context.Update(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<int> Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null");

            _entities.Remove(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
