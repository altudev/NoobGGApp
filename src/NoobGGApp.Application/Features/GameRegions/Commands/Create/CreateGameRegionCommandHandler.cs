using MediatR;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Application.Features.GameRegions.Commands.Create;

public sealed class CreateGameRegionCommandHandler : IRequestHandler<CreateGameRegionCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateGameRegionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateGameRegionCommand request, CancellationToken cancellationToken)
    {
        var gameRegion = GameRegion.Create(request.Name, request.Code, request.GameId);

        _context.GameRegions.Add(gameRegion);

        await _context.SaveChangesAsync(cancellationToken);

        return gameRegion.Id;
    }
}
