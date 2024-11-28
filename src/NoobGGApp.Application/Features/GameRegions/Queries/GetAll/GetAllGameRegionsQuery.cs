using MediatR;
using NoobGGApp.Application.Common.Attributes;
using NoobGGApp.Application.Common.Interfaces;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetAll;

[CacheOptions(absoluteExpirationMinutes: 60, slidingExpirationMinutes: 15)]
public sealed record GetAllGameRegionsQuery : IRequest<List<GameRegionGetAllDto>>, ICacheable
{

    [CacheKeyPart]
    public long GameId { get; set; }

    [CacheKeyPart]
    public string? Name { get; set; }

    [CacheKeyPart]
    public string? Code { get; set; }

    public string CacheGroup => "GameRegions";

    public GetAllGameRegionsQuery(long gameId, string? name, string? code)
    {
        GameId = gameId;
        Name = name;
        Code = code;
    }
};
