using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAspNetCore.Application.Model.Pagination
{
    public class PagedList<T> where T : class
    {
        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> List { get; }

        public int TotalPages => (int)Math.Ceiling(this.TotalItems / (double)this.PageSize);
        public bool _hasPreviousPage => this.PageNumber > 1;
        public bool _hasNextPage => this.PageNumber < this.TotalPages;
        public int _nextPageNumber => _hasNextPage ? this.PageNumber + 1 : this.TotalPages;
        public int _previousPageNumber => _hasPreviousPage ? this.PageNumber - 1 : 1;

        public PagedList(List<T> source, int pageNumber, int pageSize)
        {
            this.TotalItems = source.Count();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.List = source
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();
        }

        public PagingHeader GetHeader()
        {
            return new PagingHeader(this.TotalItems, this.PageNumber, this.PageSize, this.TotalPages);
        }
    }
}
