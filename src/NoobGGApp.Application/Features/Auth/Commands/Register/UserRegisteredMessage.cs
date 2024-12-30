using NoobGGApp.Application.Common.Models.Queues;

namespace NoobGGApp.Application.Features.Auth.Commands.Register;

public sealed class UserRegisteredMessage : BaseEmailMessage
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string VerificationToken { get; set; }

    public UserRegisteredMessage(long id, string email, string fullName, string verificationToken) : base(EmailMessageType.UserRegistered)
    {
        Id = id;
        Email = email;
        FullName = fullName;
        VerificationToken = verificationToken;

    }

    public UserRegisteredMessage() : base(EmailMessageType.UserRegistered)
    {
    }
}
