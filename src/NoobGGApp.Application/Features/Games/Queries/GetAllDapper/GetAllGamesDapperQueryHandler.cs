using MediatR;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Common.Models.Pagination;
using Dapper;
using System.Data;

namespace NoobGGApp.Application.Features.Games.Queries.GetAllDapper;

public sealed class GetAllGamesDapperQueryHandler : IRequestHandler<GetAllGamesDapperQuery, PaginatedList<GetAllGamesDapperDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAllGamesDapperQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<PaginatedList<GetAllGamesDapperDto>> Handle(GetAllGamesDapperQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("search_keyword", request.SearchKeyword);
        parameters.Add("page_number", request.PageNumber);
        parameters.Add("page_size", request.PageSize);
        parameters.Add("is_ascending", request.IsAscending);

        var totalCount = await connection.QueryFirstOrDefaultAsync<int>(
            "get_games_total_count",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        var items = await connection.QueryAsync<GetAllGamesDapperDto>(
            "get_all_games",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return new PaginatedList<GetAllGamesDapperDto>(items.ToList(), totalCount, request.PageNumber, request.PageSize);
    }
}



// CREATE OR REPLACE FUNCTION get_all_games(
//     search_keyword TEXT,
//     page_number INT,
//     page_size INT,
//     is_ascending BOOLEAN
// ) RETURNS TABLE(id BIGINT, name TEXT, description TEXT, image_url TEXT) AS $$
// BEGIN
//     RETURN QUERY
//     SELECT g.id, g.name, g.description, g.image_url
//     FROM games g
//     WHERE (search_keyword = '' OR LOWER(g.name) LIKE LOWER('%' || search_keyword || '%'))
//     ORDER BY CASE WHEN is_ascending THEN g.name END ASC,
//              CASE WHEN NOT is_ascending THEN g.name END DESC
//     LIMIT page_size OFFSET (page_number - 1) * page_size;
// END;
// $$ LANGUAGE plpgsql;


// CREATE OR REPLACE FUNCTION get_games_total_count(
//     search_keyword TEXT
// ) RETURNS INT AS $$
// DECLARE
//     total_count INT;
// BEGIN
//     SELECT COUNT(*)
//     INTO total_count
//     FROM games g
//     WHERE (search_keyword = '' OR LOWER(g.name) LIKE LOWER('%' || search_keyword || '%'));

//     RETURN total_count;
// END;
// $$ LANGUAGE plpgsql;

