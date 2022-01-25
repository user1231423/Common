using Common.Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Pagination
{
    public static class PaginationExtensions
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

        /// <summary>
        /// Page by
        /// This allows to use ToListAsync at the end of the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="query"></param>
        /// <param name="orderBy"></param>
        /// <param name="parameters"></param>
        /// <param name="orderByDescending"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<T> PageBy<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> orderBy, PaginationParams parameters, bool orderByDescending = true)
        {
            const int defaultPageNumber = 1;

            if (query == null)
                throw new ArgumentNullException(nameof(query));

            // Check if the page number is greater then zero - otherwise use default page number
            if (parameters.CurrentPage <= 0)
                parameters.CurrentPage = defaultPageNumber;

            // It is necessary sort items before it
            query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

            return query.Skip((parameters.CurrentPage - 1) * parameters.PageSize).Take(parameters.PageSize);
        }
    }
}
