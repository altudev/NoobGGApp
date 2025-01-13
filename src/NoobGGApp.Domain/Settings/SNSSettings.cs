namespace NoobGGApp.Domain.Settings;

public record class SNSSettings
{
    public string AccessKey { get; set; }
    public string SecretKey { get; set; }
    public string UserRegisteredTopicArn { get; set; }
}

