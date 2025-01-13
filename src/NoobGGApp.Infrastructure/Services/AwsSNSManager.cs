using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Options;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Features.Auth.Commands.Register; // "UserRegisteredMessage" bu namespace altındaysa
using NoobGGApp.Domain.Settings; // Ayar sınıflarınız bu ad altında olabilir

namespace NoobGGApp.Infrastructure.Services
{
    public sealed class AwsSNSManager : IMessagePublisher
    {
        private readonly IAmazonSimpleNotificationService _snsClient;
        private readonly AWSSettings _awsSettings;
        // "AwsSettings" dediğimiz, içinde Region, AccessKey, SecretKey, 
        // ve belki "SNS.UserRegisteredTopicArn" gibi parametreleri tutan 
        // bir POCO (Plain Old C# Object) class olabilir.

        public AwsSNSManager(IOptions<AWSSettings> awsSettings)
        {
            _awsSettings = awsSettings.Value;

            // SNS Client initialize
            _snsClient = new AmazonSimpleNotificationServiceClient(
                _awsSettings.SNSSettings.AccessKey,
                _awsSettings.SNSSettings.SecretKey,
                RegionEndpoint.GetBySystemName(_awsSettings.Region)
            );
        }

        public Task PublishUserRegisteredMessageAsync(
            UserRegisteredMessage message,
            CancellationToken cancellationToken = default)
        {
            var messageBody = System.Text.Json.JsonSerializer.Serialize(message);

            var publishRequest = new PublishRequest
            {
                TopicArn = _awsSettings.SNSSettings.UserRegisteredTopicArn,
                Message = messageBody
            };

            return _snsClient.PublishAsync(publishRequest, cancellationToken);
        }
    }
}
