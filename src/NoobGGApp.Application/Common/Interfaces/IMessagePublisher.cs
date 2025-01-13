using NoobGGApp.Application.Features.Auth.Commands.Register;

namespace NoobGGApp.Application.Common.Interfaces;
public interface IMessagePublisher
{
    Task PublishUserRegisteredMessageAsync(
        UserRegisteredMessage message,
        CancellationToken cancellationToken = default
    );
}

