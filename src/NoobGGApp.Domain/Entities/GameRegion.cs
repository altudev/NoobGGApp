
using NoobGGApp.Domain.Common.Entities;

namespace NoobGGApp.Domain.Entities;

public sealed class GameRegion : EntityBase<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public long GameId { get; set; }
    public Game Game { get; set; }
}
