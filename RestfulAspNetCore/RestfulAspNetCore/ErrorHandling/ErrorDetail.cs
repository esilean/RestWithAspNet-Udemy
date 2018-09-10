using Newtonsoft.Json.Serialization;

namespace RestfulAspNetCore.Services.ErrorHandling
{
    public class ErrorDetail
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public string InnerMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
