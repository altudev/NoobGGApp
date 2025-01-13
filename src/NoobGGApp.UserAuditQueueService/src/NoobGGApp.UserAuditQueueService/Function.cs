using System.Text.Json;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using NoobGGApp.Application.Common.Models.Queues;
using NoobGGApp.Application.Features.Auth.Commands.Register;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace NoobGGApp.UserAuditQueueService;

public class Function
{
    private readonly string _dynamoDbTableName;
    private readonly AmazonDynamoDBClient _dynamoDbClient;
    /// <summary>
    /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
    /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
    /// region the Lambda function is executed in.
    /// </summary>
    public Function()
    {
        _dynamoDbTableName = Environment.GetEnvironmentVariable("dynamodb_auditlogs_tablename")!;


        var config = new AmazonDynamoDBConfig
        {
            RegionEndpoint = RegionEndpoint.EUNorth1,
        };

        _dynamoDbClient = new AmazonDynamoDBClient(config);
    }


    /// <summary>
    /// This method is called for every Lambda invocation. This method takes in an SQS event object and can be used 
    /// to respond to SQS messages.
    /// </summary>
    /// <param name="evnt">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {

        foreach (var message in evnt.Records)
        {
            await ProcessMessageAsync(message, context);
        }
    }

    private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.LogInformation($"Processed message {message.Body}");

        try
        {
            var baseEmailMessage = JsonSerializer.Deserialize<BaseEmailMessage>(message.Body);


            switch (baseEmailMessage.MessageType)
            {
                case EmailMessageType.UserRegistered:
                    context.Logger.LogInformation($"Exception for Alihan!");



                    await PutItemAsync(baseEmailMessage, context);
                    break;

                case EmailMessageType.ForgotPassword:
                    // var forgotPasswordMessage = JsonSerializer.Deserialize<ForgotPasswordMessage>(message.Body);
                    break;
            }
        }
        catch (Exception ex)
        {
            context.Logger.LogError($"Error processing message {message.Body}: {ex.Message}");
            throw ex;
        }

        // TODO: Do interesting work based on the new message
        await Task.CompletedTask;
    }


    /// <summary>
    /// Adds a new item to the table.
    /// </summary>
    /// <param name="message">A BaseEmailMessage object containing informtation for
    /// the message to add to the table.</param>
    /// <returns>A Boolean value that indicates the results of adding the item.</returns>
    public async Task<bool> PutItemAsync(BaseEmailMessage message, ILambdaContext context)
    {
        var item = new Dictionary<string, AttributeValue>
        {
            ["MessageType"] = new AttributeValue { S = message.MessageType.ToString() },
            ["Message"] = new AttributeValue { S = JsonSerializer.Serialize(message) },
        };

        var request = new PutItemRequest
        {
            TableName = _dynamoDbTableName,
            Item = item,
        };

        var response = await _dynamoDbClient.PutItemAsync(request);

        context.Logger.LogInformation($"Response: {response.HttpStatusCode}");

        return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
    }



}