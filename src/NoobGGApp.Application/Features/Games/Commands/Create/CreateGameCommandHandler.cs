using System;
using MediatR;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Common.Models.Responses;
using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Application.Features.Games.Commands.Create;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, ResponseDto<long>>
{
    private readonly IApplicationDbContext _context;

    public CreateGameCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseDto<long>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var game = Game.Create(request.Name, request.Description, request.ImageUrl);

        await _context.Games.AddAsync(game, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return ResponseDto<long>.Success(game.Id, "Game created successfully");
    }
}
