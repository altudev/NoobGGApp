using NoobGGApp.Domain.Common.Entities;
using TSID.Creator.NET;

namespace NoobGGApp.Domain.Entities;

public sealed class Game : EntityBase<long>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string ImageUrl { get; set; }

    public static Game Create(string name, string description, string imageUrl)
    {
        return new Game
        {
            Id = TsidCreator.GetTsid().ToLong(),
            Name = name,
            Description = description,
            ImageUrl = imageUrl
        };
    }


    public ICollection<GameRegion> GameRegions { get; set; } = [];
    public ICollection<GameMode> GameModes { get; set; } = [];
    public ICollection<GameRank> GameRanks { get; set; } = [];


}
