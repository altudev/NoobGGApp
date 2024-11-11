using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetById;

public sealed record GameRegionGetByIdDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public long GameId { get; set; }
    public string GameName { get; set; }

    public static GameRegionGetByIdDto Create(GameRegion gameRegion) // GameRegionGetByIdDto.Create(gameRegion)
    {
        return new GameRegionGetByIdDto
        {
            Id = gameRegion.Id,
            Name = gameRegion.Name,
            Code = gameRegion.Code,
            GameId = gameRegion.GameId,
            GameName = gameRegion.Game.Name,
        };
    }

    public GameRegionGetByIdDto(long id, string name, string code, long gameId)
    {
        Id = id;
        Name = name;
        Code = code;
        GameId = gameId;
    }

    public GameRegionGetByIdDto()
    {

    }
}
