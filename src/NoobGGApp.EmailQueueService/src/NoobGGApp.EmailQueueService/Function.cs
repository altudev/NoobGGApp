using System.Text.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using NoobGGApp.Application.Common.Models.Queues;
using NoobGGApp.Application.Features.Auth.Commands.Register;
using Resend;
using Microsoft.Extensions.Options;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace NoobGGApp.EmailQueueService;

public class Function
{
    /// <summary>
    /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
    /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
    /// region the Lambda function is executed in.
    /// </summary>
    public Function()
    {

    }
    private static readonly string _resendApiKey = "";
    private static readonly IResend _resend = new ResendClient(
        Options.Create(new ResendClientOptions { ApiToken = _resendApiKey }),
        new HttpClient()
    );

    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        Converters = { new BaseEmailMessageJsonConverter() }
    };

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

        // try
        // {
        //     var baseEmailMessage = JsonSerializer.Deserialize<BaseEmailMessage>(message.Body, _jsonSerializerOptions);


        //     switch (baseEmailMessage.MessageType)
        //     {
        //         case EmailMessageType.UserRegistered:
        //             context.Logger.LogInformation($"Exception for Alihan!");
        //             throw new Exception("Alihan");
        //             await HandleUserRegisteredMessageAsync(message.Body, context);
        //             break;

        //         case EmailMessageType.ForgotPassword:
        //             // var forgotPasswordMessage = JsonSerializer.Deserialize<ForgotPasswordMessage>(message.Body);
        //             break;
        //     }
        // }
        // catch (Exception ex)
        // {
        //     context.Logger.LogError($"Error processing message {message.Body}: {ex.Message}");
        // }

        throw new Exception("Alihan");

        // TODO: Do interesting work based on the new message
        await Task.CompletedTask;
    }


    private async Task HandleUserRegisteredMessageAsync(string messageBody, ILambdaContext context)
    {
        var userRegisteredMessage = JsonSerializer.Deserialize<UserRegisteredMessage>(messageBody, _jsonSerializerOptions);

        Console.WriteLine($"UserRegisteredMessage: {userRegisteredMessage.Email}");

        var emailMessage = new EmailMessage();
        emailMessage.From = "info@yazilim.academy";
        emailMessage.To.Add(userRegisteredMessage.Email);
        emailMessage.Subject = "FENA PATLADIK!";
        emailMessage.HtmlBody = "<div><strong>Greetings<strong> 👋🏻 from AWS Lambda</div>";

        await _resend.EmailSendAsync(emailMessage);

        await Task.CompletedTask;
    }
}