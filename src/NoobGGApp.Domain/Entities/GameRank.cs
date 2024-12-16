using System;
using NoobGGApp.Domain.Common.Entities;

namespace NoobGGApp.Domain.Entities;

public sealed class GameRank : EntityBase<long>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public int Order { get; set; }

    public long GameId { get; set; }
    public Game Game { get; set; }

    // GameId = 1 // LOL
    // Name = "Gold"
    // Description = "Gold Rank"
    // ImageUrl = "https://example.com/gold.png"

    // GameId = 2 // LOL
    // Name = "Silver"
    // Description = "Silver Rank"
    // ImageUrl = "https://example.com/silver.png"

    // GameId = 3 // LOL
    // Name = "Bronze"
    // Description = "Bronze Rank"
    // ImageUrl = "https://example.com/bronze.png"

    // GameId = 4 // CSGO
    // Name = "Silver"
    // Description = "Silver Rank"
    // ImageUrl = "https://example.com/silver.png"
}
