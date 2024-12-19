using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.Enums;
using NoobGGApp.Domain.Identity;

namespace NoobGGApp.Domain.Entities;

public sealed class LobbyEventHistory : EntityBase<long>
{
    public long LobbyId { get; set; }
    public Lobby Lobby { get; set; }

    // Olay tipi: UserJoined, UserLeft, LobbyClosed, LobbyNameChanged gibi enum kullan
    public LobbyEventType EventType { get; set; }

    public long? UserId { get; set; } // Bazı event'ler kullanıcı bazlı (katıldı/ayrıldı)
    public ApplicationUser User { get; set; }

    public string? Note { get; set; } // Ek bilgi: "User joined from invite link"
}

