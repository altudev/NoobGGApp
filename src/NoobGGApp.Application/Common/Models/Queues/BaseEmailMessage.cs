namespace NoobGGApp.Application.Common.Models.Queues;

public abstract class BaseEmailMessage
{
    public EmailMessageType MessageType { get; set; } = default!; // UserRegistered, ForgotPassword, etc.

    public BaseEmailMessage(EmailMessageType messageType)
    {
        MessageType = messageType;
    }

    public BaseEmailMessage()
    {

    }
}
