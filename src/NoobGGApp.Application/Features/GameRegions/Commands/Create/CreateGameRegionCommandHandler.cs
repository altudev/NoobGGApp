using FluentValidation;
using MediatR;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Application.Features.GameRegions.Commands.Create;

public sealed class CreateGameRegionCommandHandler : IRequestHandler<CreateGameRegionCommand, long>
{
    private readonly IApplicationDbContext _context;
    private readonly ICacheInvalidator _cacheInvalidator;

    public CreateGameRegionCommandHandler(IApplicationDbContext context, ICacheInvalidator cacheInvalidator)
    {
        _context = context;
        _cacheInvalidator = cacheInvalidator;
    }

    public async Task<long> Handle(CreateGameRegionCommand request, CancellationToken cancellationToken)
    {
        var gameRegion = GameRegion.Create(request.Name, request.Code, request.GameId);

        _context.GameRegions.Add(gameRegion);

        await _context.SaveChangesAsync(cancellationToken);

        await _cacheInvalidator.InvalidateGroupAsync("GameRegions", cancellationToken);

        return gameRegion.Id;
    }
}
