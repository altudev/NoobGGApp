using Microsoft.EntityFrameworkCore;
using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<GameRegion> GameRegions { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
