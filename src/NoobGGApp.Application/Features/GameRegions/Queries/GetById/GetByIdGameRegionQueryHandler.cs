
using MediatR;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Application.Common.Interfaces;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetById;

public sealed class GetByIdGameRegionQueryHandler : IRequestHandler<GetByIdGameRegionQuery, GameRegionGetByIdDto>
{
    private readonly IApplicationDbContext _context;

    public GetByIdGameRegionQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GameRegionGetByIdDto> Handle(GetByIdGameRegionQuery request, CancellationToken cancellationToken)
    {
        var gameRegion = await _context
            .GameRegions
            .AsNoTracking()
            .Select(x => new GameRegionGetByIdDto(x.Id, x.Name, x.Code, x.GameId, x.Game.Name))
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return gameRegion!;
    }
}
