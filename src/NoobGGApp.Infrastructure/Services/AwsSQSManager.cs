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
    private readonly SQSSettings _settings;

    public AwsSQSManager(IOptions<SQSSettings> settings)
    {
        _sqsClient = new AmazonSQSClient(settings.Value.AccessKey, settings.Value.SecretKey, Amazon.RegionEndpoint.GetBySystemName(settings.Value.Region));

        _settings = settings.Value;
    }

    public Task SendUserRegisteredMessageAsync(UserRegisteredMessage message, CancellationToken cancellationToken = default)
    {
        var messageBody = JsonSerializer.Serialize(message);

        var sendMessageRequest = new SendMessageRequest(_settings.EmailQueueUrl, messageBody);

        return _sqsClient.SendMessageAsync(sendMessageRequest, cancellationToken);
    }

}
