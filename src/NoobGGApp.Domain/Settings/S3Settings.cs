namespace NoobGGApp.Domain.Settings;

public sealed record S3Settings
{
    public string BucketName { get; init; }
    public string BucketRegion { get; init; }
    public string AccessKey { get; init; }
    public string SecretKey { get; init; }
}
