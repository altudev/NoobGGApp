using NoobGGApp.Domain.Common.Events;
using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Domain.DomainEvents;

public record LobbyCreatedDomainEvent(Lobby Lobby) : IDomainEvent;
