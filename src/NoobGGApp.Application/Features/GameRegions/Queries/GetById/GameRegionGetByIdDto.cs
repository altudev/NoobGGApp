using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetById;

public sealed record GameRegionGetByIdDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public long GameId { get; set; }
    public string GameName { get; set; }

    public static GameRegionGetByIdDto Create(long id, string name, string code, long gameId, string gameName)
    {
        return new GameRegionGetByIdDto
        {
            Id = id,
            Name = name,
            Code = code,
            GameId = gameId,
            GameName = gameName,
        };
    }

    public GameRegionGetByIdDto(long id, string name, string code, long gameId, string gameName)
    {
        Id = id;
        Name = name;
        Code = code;
        GameId = gameId;
        GameName = gameName;
    }

    public GameRegionGetByIdDto()
    {

    }
}
