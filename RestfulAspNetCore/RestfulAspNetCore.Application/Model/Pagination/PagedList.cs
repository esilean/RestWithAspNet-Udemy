using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAspNetCore.Application.Model.Pagination
{
    public class PagedList<T> where T : class
    {
        public int _totalItems { get; }
        public int _pageNumber { get; }
        public int _pageSize { get; }
        public List<T> _list { get; }

        public int _totalPages => (int)Math.Ceiling(_totalItems / (double)_pageSize);
        public bool _hasPreviousPage => _pageNumber > 1;
        public bool _hasNextPage => _pageNumber < _totalPages;
        public int _nextPageNumber => _hasNextPage ? _pageNumber + 1 : _totalPages;
        public int _previousPageNumber => _hasPreviousPage ? _pageNumber - 1 : 1;

        public PagedList(List<T> source, int pageNumber, int pageSize)
        {
            _totalItems = source.Count();
            _pageNumber = pageNumber;
            _pageSize = pageSize;
            _list = source
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();
        }

        public PagingHeader GetHeader()
        {
            return new PagingHeader(_totalItems, _pageNumber, _pageSize, _totalPages);
        }
    }
}
