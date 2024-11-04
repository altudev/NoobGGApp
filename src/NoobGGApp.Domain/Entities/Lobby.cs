using System;
using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.DomainEvents;

namespace NoobGGApp.Domain.Entities;

public class Lobby : EntityBase<long>
{
    public long GameId { get; private set; }
    public long GameModeId { get; private set; }
    public long GameRegionId { get; private set; }
    public long CreatorId { get; private set; }

    public static Lobby Create(long gameId, long gameModeId, long gameRegionId, long customerId)
    {
        var lobby = new Lobby()
        {
            GameId = gameId,
            GameModeId = gameModeId,
            GameRegionId = gameRegionId,
            CreatorId = customerId
        };

        lobby.RaiseDomainEvent(new LobbyCreatedDomainEvent(lobby));

        return lobby;

        //var events = entity.GetDomainEvents()

        // Mediator.Publish(new LobbyCreatedDomainEvent(lobby));    
    }


    // private void Handle(LobbyCreatedDomainEvent domainEvent)
    // {
    //     _emailService.SendEmailAsync(domainEvent.Lobby.CreatorId, "Lobby Created", "Your lobby has been created");
    // }
}
