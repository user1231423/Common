using Common.Pagination.Models;
using Data.Authentication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Insert(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Update(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Delete(T entity);

        /// <summary>
        /// List entities
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Task<List<T>> List(PaginationParams pagination);

        /// <summary>
        /// Get table
        /// </summary>
        IQueryable<T> Table { get; }
    }
}
