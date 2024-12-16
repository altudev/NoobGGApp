using NoobGGApp.Domain.Common.Entities;

namespace NoobGGApp.Domain.Entities;

public sealed class Language : EntityBase<long>
{
    public string Name { get; set; }
    public string Code { get; set; }

    public ICollection<LobbyLanguage> LobbyLanguages { get; set; } = [];
}
