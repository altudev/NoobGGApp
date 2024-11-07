
using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.DomainEvents;
using TSID.Creator.NET;

namespace NoobGGApp.Domain.Entities;

public sealed class GameRegion : EntityBase<long>
{
    public string Name { get; private set; }
    public string Code { get; private set; }

    public long GameId { get; private set; }
    public Game Game { get; private set; }

    public static GameRegion Create(string name, string code, long gameId)
    {
        var gameRegion = new GameRegion
        {
            Id = TsidCreator.GetTsid().ToLong(),
            Name = name,
            Code = code,
            GameId = gameId,
        };

        gameRegion.RaiseDomainEvent(new GameRegionCreatedDomainEvent(gameRegion.Id));

        return gameRegion;
    }
}



