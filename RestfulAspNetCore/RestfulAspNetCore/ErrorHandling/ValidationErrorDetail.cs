using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAspNetCore.Services.ErrorHandling
{
    public class ValidationErrorDetail : ErrorDetail
    {
        public ICollection<ValidationError> ValidationErrors { get; set; }
    }
}
public class ValidationError
{
    public string Name { get; set; }
    public string Description { get; set; }
}
