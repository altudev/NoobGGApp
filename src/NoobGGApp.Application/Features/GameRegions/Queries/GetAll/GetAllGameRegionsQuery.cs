using MediatR;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetAll;

public sealed record GetAllGameRegionsQuery : IRequest<List<GameRegionGetAllDto>>
{
    public long? GameId { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }

    public GetAllGameRegionsQuery(long? gameId, string? name, string? code)
    {
        GameId = gameId;
        Name = name;
        Code = code;
    }
};
