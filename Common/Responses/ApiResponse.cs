namespace ApiGestaoProcessos.Common.Responses
{
    public class ApiResponse
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public ApiMeta Meta { get; init; } = new();
    }
}
