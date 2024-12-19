namespace NoobGGApp.WebApi.Models;

public record S3UploadObjectRequestDto
{
    public IFormFile File { get; init; }
}
