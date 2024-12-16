using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Configurations;

public class LobbyConfiguration : IEntityTypeConfiguration<Lobby>
{
    public void Configure(EntityTypeBuilder<Lobby> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.RowVersion)
        .IsRowVersion()
        .IsConcurrencyToken();
    }
}
