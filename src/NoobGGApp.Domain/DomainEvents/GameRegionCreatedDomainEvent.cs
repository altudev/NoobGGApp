using NoobGGApp.Domain.Common.Events;

namespace NoobGGApp.Domain.DomainEvents;

public record GameRegionCreatedDomainEvent(long GameRegionId) : IDomainEvent;
