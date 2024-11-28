using MediatR;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetById;


public sealed record GetByIdGameRegionQuery(long Id) : IRequest<GameRegionGetByIdDto>;
