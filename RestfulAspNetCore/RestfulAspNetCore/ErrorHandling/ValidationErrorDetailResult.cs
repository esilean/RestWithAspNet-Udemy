using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAspNetCore.Services.ErrorHandling
{
    public class ValidationErrorDetailResult : IActionResult
    {
        public Task ExecuteResultAsync(ActionContext context)
        {
            var modelStateEntries = context.ModelState.Where(e => e.Value.Errors.Count > 0).ToArray();

            var errors = new List<ValidationError>();

            var details = "See ValidationErrors for details";

            if (modelStateEntries.Any())
            {
                if (modelStateEntries.Length == 1 && modelStateEntries[0].Value.Errors.Count == 1 && modelStateEntries[0].Key == string.Empty)
                {
                    details = modelStateEntries[0].Value.Errors[0].ErrorMessage;
                }
                else
                {
                    foreach (var modelStateEntry in modelStateEntries)
                    {
                        foreach (var modelStateError in modelStateEntry.Value.Errors)
                        {
                            var error = new ValidationError
                            {
                                Name = modelStateEntry.Key,
                                Description = modelStateError.ErrorMessage
                            };

                            errors.Add(error);
                        }

                    }
                }
            }

            var errorDetail = new ValidationErrorDetail
            {
                Status = 400,
                Title = "Erro de validação da solicitação",
                Instance = $"urn:bevixy:badrequest:{Guid.NewGuid()}",
                Detail = details,
                ValidationErrors = errors
            };

            context.HttpContext.Response.StatusCode = 400;
            context.HttpContext.Response.WriteJson(errorDetail);
            return Task.CompletedTask;
        }
    }
}
