using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.Identity;

namespace NoobGGApp.Domain.Entities;

public sealed class LobbyMessage : EntityBase<long>
{
    public long LobbyId { get; set; }
    public Lobby Lobby { get; set; }
    public long SenderId { get; set; }
    public ApplicationUser Sender { get; set; }
    public string Content { get; set; }

}
