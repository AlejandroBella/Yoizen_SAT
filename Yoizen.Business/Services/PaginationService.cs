using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoizen.Business.Entities;

namespace Yoizen.Business.Services
{
    internal static class PaginationService<T>
    {
        public static PagedDocs<T> GetPages(List<T> docs, PagingParameters pageParams)
        {
            var result = new PagedDocs<T>();
            result.TotalDocs = docs.Count;
            result.Limit = pageParams.PageLimit;

            if (result.TotalDocs <= result.Limit)
            {
                result.Docs = docs;
                result.Page = 1;
                result.TotalPages = 1;
                result.HasPrevPage = false;
                result.HasNextPage = false;
                result.NextPage = 1;
                result.PrevPage = 1;
                result.PagingCounter = 1;
            }
            else
            {
                double total = result.TotalDocs / result.Limit;
                result.TotalPages = (int)Math.Ceiling(total);
                if (pageParams.PageIndex > result.TotalPages)
                {
                    throw new KeyNotFoundException("Page not found");
                }

                result.Page = pageParams.PageIndex;
                var contador = (result.Page - 1) * result.Limit;
                result.Docs = docs.Skip(contador).Take(result.Limit).ToList();

                result.HasPrevPage = pageParams.PageIndex > 1;
                result.HasNextPage = pageParams.PageIndex < result.TotalPages;
                result.NextPage = result.HasNextPage ? result.Page++ : result.Page;
                result.PrevPage = result.HasPrevPage ? result.Page-- : result.Page;
                result.PagingCounter = contador+1;
            }

            return result;
        }
    }
}
