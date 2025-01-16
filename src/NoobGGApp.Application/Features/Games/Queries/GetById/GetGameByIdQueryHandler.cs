using System;
using Dapper;
using MediatR;
using NoobGGApp.Application.Common.Interfaces;

namespace NoobGGApp.Application.Features.Games.Queries.GetById;

public sealed class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GetGameByIdDto>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetGameByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<GetGameByIdDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var query = """
            SELECT id, name, description, image_url
            FROM games
            WHERE id = @Id
            """;

        var game = await connection.QueryFirstOrDefaultAsync<GetGameByIdDto>(
            query,
            new { Id = request.Id }
        );

        return game;
    }
}
