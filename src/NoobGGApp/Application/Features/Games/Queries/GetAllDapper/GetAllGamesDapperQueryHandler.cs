using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Common.Models;
using NoobGGApp.Application.Features.Games.Queries.GetAllDapper;

namespace NoobGGApp.Application.Features.Games.Queries.GetAllDapper
{
    public class GetAllGamesDapperQueryHandler : IRequestHandler<GetAllGamesDapperQuery, PaginatedList<GetAllGamesDapperDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllGamesDapperQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<PaginatedList<GetAllGamesDapperDto>> Handle(GetAllGamesDapperQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add("@Offset", (request.PageNumber - 1) * request.PageSize);
            parameters.Add("@SearchKeyword", string.IsNullOrEmpty(request.SearchKeyword) ? null : $"%{request.SearchKeyword.ToLower()}%");

            var orderDirection = request.IsAscending ? "ASC" : "DESC";

            var query = @$"
                WITH FilteredGames AS (
                    SELECT *
                    FROM Games
                    WHERE @SearchKeyword IS NULL OR LOWER(name) LIKE @SearchKeyword
                )
                SELECT 
                    id as Id,
                    name as Name,
                    description as Description,
                    image_url as ImageUrl
                FROM FilteredGames
                ORDER BY name {orderDirection}
                LIMIT @PageSize OFFSET @Offset;

                SELECT COUNT(*)
                FROM FilteredGames;";

            using var multi = await connection.QueryMultipleAsync(query, parameters);

            var games = await multi.ReadAsync<GetAllGamesDapperDto>();

            var totalCount = await multi.ReadFirstAsync<int>();

            return new PaginatedList<GetAllGamesDapperDto>(games, totalCount, request.PageNumber, request.PageSize);
        }
    }
}