using NoobGGApp.Domain.Common.Entities;

namespace NoobGGApp.Domain.Entities;

public sealed class GameMode : EntityBase<long>
{
    // Solo/Duo
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public int MinTeamSize { get; set; } = 1;
    public int MaxTeamSize { get; set; } = 3;

    public long GameId { get; set; }
    public Game Game { get; set; }
}
