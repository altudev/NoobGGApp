using NoobGGApp.Application.Common.Models.Errors;

namespace NoobGGApp.Application.Common.Models.Responses;

public sealed record ResponseDto<T>
{
    public T? Data { get; init; }
    public string? Message { get; init; }
    public bool IsSuccess { get; init; }
    public IReadOnlyList<ValidationError> ValidationErrors { get; init; }

    public ResponseDto(T? data, string? message, bool isSuccess, IReadOnlyList<ValidationError>? validationErrors = null)
    {
        Data = data;
        Message = message;
        IsSuccess = isSuccess;
        ValidationErrors = validationErrors ?? Array.Empty<ValidationError>();
    }

    public static ResponseDto<T> Success(T data, string message)
        => new(data, message, true);

    public static ResponseDto<T?> Success(string message)
        => new(default, message, true);

    public static ResponseDto<T> Error(string message, List<ValidationError>? validationErrors = null)
        => new(default, message, false, validationErrors);

    public static ResponseDto<T> Error(string message, ValidationError validationError)
        => new(default, message, false, new[] { validationError });
}
