using MediatR;
using NoobGGApp.Application.Common.Models.Responses;

namespace NoobGGApp.Application.Features.Auth.Commands.Register;

public sealed record AuthRegisterCommand(string Email, string Password, string FullName) : IRequest<ResponseDto<string>>;
