using NoobGGApp.Application.Features.Auth.Commands.Register;

namespace NoobGGApp.Application.Common.Interfaces;

public interface IMessageQueueService
{
    Task SendUserRegisteredMessageAsync(UserRegisteredMessage message, CancellationToken cancellationToken = default);
}
