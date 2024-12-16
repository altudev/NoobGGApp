using NoobGGApp.Domain.Common.Entities;

namespace NoobGGApp.Domain.Entities;

public sealed class LobbyLanguage : EntityBase<long>
{
    public long LobbyId { get; set; }
    public Lobby Lobby { get; set; }
    public long LanguageId { get; set; }
    public Language Language { get; set; }

    // YazilimAcademyHalfLifeLobisi LobbyId = 1
    // LobbyId = 1, LanguageId = 1 // Turkish
    // LobbyId = 1, LanguageId = 2 // English
}
