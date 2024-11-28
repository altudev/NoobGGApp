using System;

namespace NoobGGApp.Application.Common.Interfaces;

public interface ICacheInvalidator
{
    Task InvalidateAsync(string cacheKey, CancellationToken cancellationToken);
    Task InvalidateGroupAsync(string cacheGroup, CancellationToken cancellationToken);
}
