using MediatR;

namespace NoobGGApp.Application.Features.GameRegions.Commands.Create;

public sealed record CreateGameRegionCommand(string Name, string Code, long GameId) : IRequest<long>;


