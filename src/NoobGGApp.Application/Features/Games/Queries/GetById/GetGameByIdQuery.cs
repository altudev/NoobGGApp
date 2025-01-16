using MediatR;

namespace NoobGGApp.Application.Features.Games.Queries.GetById;

public sealed record GetGameByIdQuery(long Id) : IRequest<GetGameByIdDto>;


