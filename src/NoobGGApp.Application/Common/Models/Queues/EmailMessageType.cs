namespace NoobGGApp.Application.Common.Models.Queues;

public enum EmailMessageType
{
    UserRegistered = 1,
    ForgotPassword = 2,
    VerifyEmail = 3,
    VerifyPhoneNumber = 4,
    VerifyEmailChange = 5,
    VerifyPhoneNumberChange = 6,
}
