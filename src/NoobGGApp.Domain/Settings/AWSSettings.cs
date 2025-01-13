namespace NoobGGApp.Domain.Settings;

public record class AWSSettings
{
    public string Region { get; set; }

    public SNSSettings SNSSettings { get; set; }
    public SQSSettings SQSSettings { get; set; }
    public S3Settings S3Settings { get; set; }
}
