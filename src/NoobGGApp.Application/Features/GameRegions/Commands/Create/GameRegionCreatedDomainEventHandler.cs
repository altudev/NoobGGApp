using System;
using MediatR;
using Microsoft.Extensions.Logging;
using NoobGGApp.Domain.DomainEvents;

namespace NoobGGApp.Application.Features.GameRegions.Commands.Create;

public sealed class GameRegionCreatedDomainEventHandler : INotificationHandler<GameRegionCreatedDomainEvent>
{
    private readonly ILogger<GameRegionCreatedDomainEventHandler> _logger;

    public GameRegionCreatedDomainEventHandler(ILogger<GameRegionCreatedDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(GameRegionCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Game region created: {GameRegionId}", notification.GameRegionId);

        return Task.CompletedTask;
    }
}
