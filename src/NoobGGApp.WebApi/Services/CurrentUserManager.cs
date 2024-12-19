using System;
using NoobGGApp.Application.Common.Interfaces;

namespace NoobGGApp.WebApi.Services;

public class CurrentUserManager : ICurrentUserService
{
    public long? UserId => 123456;
}
