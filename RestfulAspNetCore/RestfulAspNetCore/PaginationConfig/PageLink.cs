using Microsoft.AspNetCore.Mvc;
using RestfulAspNetCore.Application.Model.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAspNetCore.Services.PaginationConfig
{
    public static class PageLink<T> where T : class
    {

        public static List<LinkInfo> GetLinks(IUrlHelper urlHelper, string routeName, PagedList<T> list)
        {
            var links = new List<LinkInfo>();

            if (list._hasPreviousPage)
                links.Add(CreateLink(urlHelper, routeName, list._previousPageNumber, list._pageSize, "previousPage", "GET"));

            links.Add(CreateLink(urlHelper, routeName, list._pageNumber, list._pageSize, "self", "GET"));

            if (list._hasNextPage)
                links.Add(CreateLink(urlHelper, routeName, list._nextPageNumber, list._pageSize, "nextPage", "GET"));

            return links;
        }

        public static LinkInfo CreateLink(IUrlHelper urlHelper, string routeName, int pageNumber, int pageSize, string rel, string method)
        {
            return new LinkInfo
            {
                Href = urlHelper.Link(routeName, new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
        }

    }
}
