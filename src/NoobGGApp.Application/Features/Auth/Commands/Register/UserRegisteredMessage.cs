namespace NoobGGApp.Application.Features.Auth.Commands.Register;

public sealed record UserRegisteredMessage
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string VerificationToken { get; set; }

    public UserRegisteredMessage(long id, string email, string fullName, string verificationToken)
    {
        Id = id;
        Email = email;
        FullName = fullName;
        VerificationToken = verificationToken;
    }
}
