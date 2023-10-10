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
                if (pageParams.PageIndex <= result.TotalPages)
                {
                    result.Page = pageParams.PageIndex;
                    result.Docs = docs.Skip((result.Page - 1) * result.Limit).Take(result.Limit).ToList();
                }
                else
                {
                    throw new KeyNotFoundException("Page not found");
                }
                result.HasPrevPage = pageParams.PageIndex > 1;
                result.HasNextPage = pageParams.PageIndex < result.TotalPages;
                result.NextPage = result.HasNextPage ? result.Page++ : result.Page;
                result.PrevPage = result.HasPrevPage ? result.Page-- : result.Page;
                result.PagingCounter = result.Page == 1? 1:result.Page + result.Limit;
            }

            return result;
        }
    }
}
