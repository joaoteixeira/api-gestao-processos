using ApiGestaoProcessos.Common.Validation;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestaoProcessos.Common.Configurations
{
    public class ApiBehaviorConfiguration
    {
        public static void Configure(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var response = new ValidationErrorResponse
                {
                    Success = false,
                    Message = "Erro de validação",
                    Errors = context.ModelState
                        .Where(x => x.Value!.Errors.Any())
                        .Select(x => new ValidationFieldError
                        {
                            Field = x.Key,
                            Messages = x.Value!.Errors
                                .Select(e => e.ErrorMessage)
                                .ToList()
                        })
                        .ToList()
                };

                return new BadRequestObjectResult(response);
            };
        }
    }
}
