
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Domain.Common.Entities;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Interceptors;

public class EntityInterceptor : SaveChangesInterceptor
{

    private readonly ICurrentUserService _currentUserService;
    public EntityInterceptor(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateAuditableEntities(eventData.Context);

        return result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities(eventData.Context);

        return new ValueTask<InterceptionResult<int>>(result);
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        UpdateAuditableEntities(eventData.Context);

        return result;
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities(eventData.Context);

        return new ValueTask<int>(result);
    }

    private void UpdateAuditableEntities(DbContext? context)
    {

        if (context is null)
            return;

        var createdByEntries = context
        .ChangeTracker
        .Entries<ICreatedByEntity>()
        .Where(e => e.State is EntityState.Added);


        foreach (var entry in createdByEntries)
        {
            entry.Entity.CreatedByUserId = _currentUserService.UserId.HasValue ? _currentUserService.UserId.Value.ToString() : null;

            entry.Entity.CreatedOn = DateTimeOffset.UtcNow;
        }

        var modifiedByEntries = context
        .ChangeTracker
        .Entries<IModifiedByEntity>()
        .Where(e => e.State is EntityState.Modified);

        foreach (var entry in modifiedByEntries)
        {
            entry.Entity.ModifiedByUserId = _currentUserService.UserId.HasValue ? _currentUserService.UserId.Value.ToString() : null;

            entry.Entity.ModifiedOn = DateTimeOffset.UtcNow;
        }
    }
}
