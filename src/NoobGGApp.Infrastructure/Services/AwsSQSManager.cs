using System;
using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Features.Auth.Commands.Register;
using NoobGGApp.Domain.Settings;

namespace NoobGGApp.Infrastructure.Services;

public sealed class AwsSQSManager : IMessageQueueService
{
    private readonly IAmazonSQS _sqsClient;
    private readonly AWSSettings _settings;

    public AwsSQSManager(IOptions<AWSSettings> settings)
    {
        _sqsClient = new AmazonSQSClient(settings.Value.SQSSettings.AccessKey, settings.Value.SQSSettings.SecretKey, Amazon.RegionEndpoint.GetBySystemName(settings.Value.SQSSettings.Region));

        _settings = settings.Value;
    }

    public Task SendUserRegisteredMessageAsync(UserRegisteredMessage message, CancellationToken cancellationToken = default)
    {
        var messageBody = JsonSerializer.Serialize(message);

        var sendMessageRequest = new SendMessageRequest(_settings.SQSSettings.EmailQueueUrl, messageBody);

        return _sqsClient.SendMessageAsync(sendMessageRequest, cancellationToken);
    }

}
