using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Application.Common.Interfaces;

namespace NoobGGApp.Application.Features.GameRegions.Commands.Create;

public sealed class CreateGameRegionCommandValidator : AbstractValidator<CreateGameRegionCommand>
{
    private readonly IApplicationDbContext _context;
    public CreateGameRegionCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage("Name is required")
        .MaximumLength(100)
        .WithMessage("Name must be at most 100 characters long")
        .MinimumLength(3)
        .WithMessage("Name must be at least 3 characters long")
        .MustAsync((command, name, cancellationToken) => CheckIfTheGameRegionAlreadyExists(command, cancellationToken))
        .WithMessage("Game region already exists");

        RuleFor(x => x.Code)
        .NotEmpty()
        .WithMessage("Code is required")
        .MaximumLength(10)
        .WithMessage("Code must be at most 10 characters long")
        .MinimumLength(3)
        .WithMessage("Code must be at least 3 characters long")
        .Must(CheckIfCodeIsValid)
        .WithMessage("Code is invalid");

        RuleFor(x => x.GameId)
        .NotEmpty()
        .WithMessage("GameId is required")
        .MustAsync(CheckIfGameExists)
        .WithMessage("Game not found");
    }

    private async Task<bool> CheckIfTheGameRegionAlreadyExists(CreateGameRegionCommand command, CancellationToken cancellationToken)
    {
        return !await _context
        .GameRegions
        .AnyAsync(x => x.Name.ToLower() == command.Name.ToLower() && x.GameId == command.GameId, cancellationToken);
    }

    // private async Task<bool> CheckIfTheGameRegionAlreadyExists(string name, long gameId, CancellationToken cancellationToken)
    // {
    //     return !await _context
    //     .GameRegions
    //     .AnyAsync(x => x.Name.ToLower() == name.ToLower() && x.GameId == gameId, cancellationToken);
    // }

    private Task<bool> CheckIfGameExists(long gameId, CancellationToken cancellationToken)
    {
        return _context
        .Games
        .AnyAsync(x => x.Id == gameId, cancellationToken);
    }

    private static bool CheckIfCodeIsValid(string code)
    => code.Length == 10 && code.Contains('-');
}
