using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Application.Common.Interfaces;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetAll;

public sealed class GetAllGameRegionsQueryHandler : IRequestHandler<GetAllGameRegionsQuery, List<GameRegionGetAllDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllGameRegionsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<GameRegionGetAllDto>> Handle(GetAllGameRegionsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.GameRegions.AsQueryable();

        query = query.Where(x => x.GameId == request.GameId);

        if (!string.IsNullOrEmpty(request.Name))
            query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

        if (!string.IsNullOrEmpty(request.Code))
            query = query.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));

        return query
        .AsNoTracking()
        .Select(x => new GameRegionGetAllDto(x.Id, x.Name, x.Code, x.GameId))
        .ToListAsync(cancellationToken);
    }

    // public Task<List<GameRegionGetAllDto>> Handle(GetAllGameRegionsQuery request, CancellationToken cancellationToken)
    // {
    //     return _context
    //          .GameRegions
    //          .AsNoTracking()
    //          .Where(x => x.GameId == request.GameId)
    //          .Select(x => GameRegionGetAllDto.Create(x))
    //          .ToListAsync(cancellationToken);
    // }
}
