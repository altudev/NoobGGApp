using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.DomainEvents;
using NoobGGApp.Domain.Enums;
using NoobGGApp.Domain.Identity;

namespace NoobGGApp.Domain.Entities;

public class Lobby : EntityBase<long>
{
    public LobbyType Type { get; private set; }
    public long GameId { get; private set; }
    public Game Game { get; private set; }
    public long GameModeId { get; private set; }
    public GameMode GameMode { get; private set; }
    public long GameRegionId { get; private set; }
    public GameRegion GameRegion { get; private set; }
    public long? MinGameRankId { get; private set; }
    public GameRank MinGameRank { get; private set; }
    public long? MaxGameRankId { get; private set; }
    public GameRank MaxGameRank { get; private set; }

    public int MinTeamSize { get; set; } = 1;
    public int MaxTeamSize { get; set; } = 3;

    public string? Note { get; set; }
    public bool IsMicrophoneRequired { get; private set; }

    public long CreatorId { get; private set; }
    public ApplicationUser Creator { get; private set; }

    public long OwnerId { get; private set; }
    public ApplicationUser Owner { get; private set; }
    // Bu alan optimistic concurrency için eklendi.
    // Bu sayede SaveChanges() esnasında kontrol edilir.
    public byte[] RowVersion { get; private set; }

    public ICollection<LobbyLanguage> LobbyLanguages { get; private set; } = [];


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
