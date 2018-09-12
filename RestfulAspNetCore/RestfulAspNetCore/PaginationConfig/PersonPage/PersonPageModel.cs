using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Application.Model.Pagination;
using System.Collections.Generic;

namespace RestfulAspNetCore.Services.PaginationConfig.PersonPage
{
    public class PersonPageModel
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<PersonModel> Items { get; set; }
    }
}
