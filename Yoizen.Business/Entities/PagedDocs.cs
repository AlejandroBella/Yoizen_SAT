using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoizen.Business.Entities
{
    public class PagedDocs<T>
    {
        public List<T> Docs { get; set; }
        public int TotalDocs { get; set;}
        public int Limit { get; set;}
        public bool HasPrevPage { get; set;}
        public bool HasNextPage { get; set;}
        public int Page { get; set;}
        public int TotalPages { get; set;}
        public int PrevPage { get; set;}
        public int NextPage { get; set;}
        public int PagingCounter { get; set;}
    }
}
