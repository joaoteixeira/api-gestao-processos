using ApiGestaoProcessos.Common.Responses;

namespace ApiGestaoProcessos.Common.Validation
{
    public class ValidationErrorResponse : ApiResponse
    {
        public List<ValidationFieldError> Errors { get; set; } = [];

    }

    public class ValidationFieldError
    {
        public string Field { get; set; } = string.Empty;

        public List<string> Messages { get; set; } = [];
    }
}
