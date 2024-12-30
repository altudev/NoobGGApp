using System;
using Microsoft.AspNetCore.Identity;
using NoobGGApp.Domain.Common.Events;

namespace NoobGGApp.Domain.Common.Entities;

public abstract class IdentityUserBase<TKey> : IdentityUser<TKey>, IEntity<TKey>, ICreatedByEntity, IModifiedByEntity where TKey : IEquatable<TKey>
{
    public virtual string CreatedByUserId { get; set; }
    public virtual DateTimeOffset CreatedOn { get; set; }
    public virtual string? ModifiedByUserId { get; set; }
    public virtual DateTimeOffset? ModifiedOn { get; set; }

    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

    public void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();
}
