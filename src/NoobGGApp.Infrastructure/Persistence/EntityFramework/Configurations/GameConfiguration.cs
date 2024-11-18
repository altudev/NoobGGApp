using System;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Configurations;

public sealed class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Game> builder)
    {
        


        // Relationships
        builder.HasMany<GameRegion>(x => x.GameRegions)
        .WithOne(x => x.Game)
        .HasForeignKey(x => x.GameId);
    }
}
