using Common.Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Pagination
{
    public static class PaginationManager
    {
        /// <summary>
        /// Get meta data from paged list
        /// </summary>
        /// <param name="paginatedResult"></param>
        /// <returns></returns>
        public static object GetMetaData<T>(this PagedList<T> paginatedResult)
        {
            return new
            {
                paginatedResult.TotalCount,
                paginatedResult.PageSize,
                paginatedResult.CurrentPage,
                paginatedResult.TotalPages,
                paginatedResult.HasNext,
                paginatedResult.HasPrevious
            };
        }

        /// <summary>
        /// Generic extension to paginate results
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static PagedList<T> ToPagedList<T>(this List<T> source, PaginationParams parameters)
        {
            var count = source.Count();
            var items = source.Skip((parameters.CurrentPage - 1) * parameters.PageSize).Take(parameters.PageSize).ToList();

            return new PagedList<T>(items, count, parameters.CurrentPage, parameters.PageSize);
        }

        /// <summary>
        /// Generic extension to paginate results
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams parameters)
        {
            var count = source.Count();
            var items = source.Skip((parameters.CurrentPage - 1) * parameters.PageSize).Take(parameters.PageSize).ToList();

            return new PagedList<T>(items, count, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
