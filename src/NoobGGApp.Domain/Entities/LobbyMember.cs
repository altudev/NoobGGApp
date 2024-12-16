using System;
using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.Identity;

namespace NoobGGApp.Domain.Entities;

public class LobbyMember : EntityBase<long>
{
    public long LobbyId { get; set; }
    public Lobby Lobby { get; set; }

    public long UserId { get; set; }
    public ApplicationUser User { get; set; }

    public bool IsAdmin { get; set; }
}
