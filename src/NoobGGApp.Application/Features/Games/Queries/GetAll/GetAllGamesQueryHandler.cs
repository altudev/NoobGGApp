using MediatR;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Common.Models.Pagination;

namespace NoobGGApp.Application.Features.Games.Queries.GetAll;

public sealed class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, PaginatedList<GetAllGamesDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllGamesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<GetAllGamesDto>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        var query = _context
        .Games
        .AsQueryable()
        .AsNoTracking();

        if (!string.IsNullOrEmpty(request.SearchKeyword))
            query = query.Where(x => x.Name.ToLower().Contains(request.SearchKeyword.ToLower()));

        query = request.IsAscending ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
        .Skip((request.PageNumber - 1) * request.PageSize)
        .Take(request.PageSize)
        .Select(x => new GetAllGamesDto(x.Id, x.Name, x.Description, x.ImageUrl))
        .ToListAsync(cancellationToken);

        return new PaginatedList<GetAllGamesDto>(items, totalCount, request.PageNumber, request.PageSize);
    }
}
