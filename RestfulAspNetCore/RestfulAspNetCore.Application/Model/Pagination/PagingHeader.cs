using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RestfulAspNetCore.Application.Model.Pagination
{
    public class PagingHeader
    {

        public int _totalItems { get; }
        public int _pageNumber { get; }
        public int _pageSize { get; }
        public int _totalPages { get; }

        public PagingHeader(int totalItems, int pageNumber, int pageSize, int totalPages)
        {
            _totalItems = totalItems;
            _pageNumber = pageNumber;
            _pageSize = pageSize;
            _totalPages = totalPages;
        }

        public string ToJson() => JsonConvert.SerializeObject(this, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    }
}
