using NoobGGApp.Domain.Common.Entities;

namespace NoobGGApp.Domain.Entities;

public sealed class Game : EntityBase<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Tags { get; set; }


    public ICollection<GameRegion> GameRegions { get; set; } = [];
    public ICollection<GameMode> GameModes { get; set; } = [];
    public ICollection<GameRank> GameRanks { get; set; } = [];


}
