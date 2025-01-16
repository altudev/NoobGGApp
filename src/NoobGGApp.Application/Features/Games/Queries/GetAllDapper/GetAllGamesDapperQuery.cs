using MediatR;
using NoobGGApp.Application.Common.Models.Pagination;

namespace NoobGGApp.Application.Features.Games.Queries.GetAllDapper;

public sealed record GetAllGamesDapperQuery : IRequest<PaginatedList<GetAllGamesDapperDto>>
{
    public string SearchKeyword { get; set; } = string.Empty;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public bool IsAscending { get; set; } = true;

    public GetAllGamesDapperQuery(string searchKeyword, int pageNumber, int pageSize, bool isAscending)
    {
        SearchKeyword = searchKeyword;
        PageNumber = pageNumber;
        PageSize = pageSize;
        IsAscending = isAscending;
    }

}