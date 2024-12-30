using System;
using Microsoft.AspNetCore.Identity;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Application.Features.Auth.Commands.Register;
using NoobGGApp.Domain.Identity;

namespace NoobGGApp.Infrastructure.Services;

public sealed class IdentityManager : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityManager(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> RegisterAsync(AuthRegisterCommand command, CancellationToken cancellationToken)
    {
        var user = ApplicationUser.Create(command.FullName, command.Email);

        var result = await _userManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }

        return user.Id.ToString();
    }
}

