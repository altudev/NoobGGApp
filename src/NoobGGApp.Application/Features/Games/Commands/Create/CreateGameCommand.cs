using MediatR;
using NoobGGApp.Application.Common.Models.Responses;

namespace NoobGGApp.Application.Features.Games.Commands.Create;

public sealed record CreateGameCommand(string Name, string Description, string ImageUrl) : IRequest<ResponseDto<long>>;


