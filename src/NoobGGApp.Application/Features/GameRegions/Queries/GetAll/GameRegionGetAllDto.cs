using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetAll;

public sealed record GameRegionGetAllDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public long GameId { get; set; }
    public string Code1 { get; set; }
    public string Code2 { get; set; }
    public string Code3 { get; set; }
    public string Code4 { get; set; }
    public string Code5 { get; set; }
    public string Code6 { get; set; }
    public string Code7 { get; set; }
    public string Code8 { get; set; }
    public string Code9 { get; set; }
    public string Code10 { get; set; }

    public static GameRegionGetAllDto Create(GameRegion gameRegion)
    {
        return new GameRegionGetAllDto
        {
            Id = gameRegion.Id,
            Name = gameRegion.Name,
            Code = gameRegion.Code,
            GameId = gameRegion.GameId,
        };
    }

    public GameRegionGetAllDto(long id, string name, string code, long gameId)
    {
        Id = id;
        Name = name;
        Code = code;
        GameId = gameId;
    }

    public GameRegionGetAllDto()
    {

    }
}
