using Common.Pagination.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Common.Pagination.Test
{
    [TestClass]
    public class PaginationTest
    {
        [TestMethod]
        public void ConvertToPagedList()
        {
            var list = new List<string>() { "a", "b", "c" };

            var paginationParams = new PaginationParams()
            {
                CurrentPage = 1,
                PageSize = 2
            };

            var pagedList = list.ToPagedList(paginationParams);

            var metadata = pagedList.GetMetaData();

            Assert.IsTrue(pagedList.Count() == paginationParams.PageSize);
        }
    }
}
