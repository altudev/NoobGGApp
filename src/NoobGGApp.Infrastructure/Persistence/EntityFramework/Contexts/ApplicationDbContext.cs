using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.Entities;
using NoobGGApp.Domain.Identity;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContext
{
    private readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<GameRegion> GameRegions { get; set; }
    public DbSet<Game> Games { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchDomainEventsAsync(cancellationToken);

        return result;
    }


    private async Task DispatchDomainEventsAsync(CancellationToken cancellationToken)
    {
        var domainEvents = ChangeTracker
        .Entries<EntityBase<long>>()
        .Select(e => e.Entity)
        .Where(e => e.GetDomainEvents().Any())
        .ToArray();

        foreach (var entity in domainEvents)
        {
            var events = entity.GetDomainEvents();

            foreach (var domainEvent in events)
                await _publisher.Publish(domainEvent, cancellationToken);

            entity.ClearDomainEvents();
        }
    }
}
