namespace NoobGGApp.Domain.Settings;

public sealed record SQSSettings
{
    public string EmailQueueUrl { get; set; }
    public string AccessKey { get; set; }
    public string SecretKey { get; set; }
    public string Region { get; set; }
}


