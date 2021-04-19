namespace Common.Pagination.Models
{
    using System;
    using System.Collections.Generic;

    public class PagedList<T> : List<T>
    {
        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total count
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Has previous page?
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;

        /// <summary>
        /// Has next page?
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items"></param>
        /// <param name="count"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }
    }
}
