using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoobGGApp.Domain.Entities;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Configurations;

public sealed class GameRegionConfiguration : IEntityTypeConfiguration<GameRegion>
{
    public void Configure(EntityTypeBuilder<GameRegion> builder)
    {
        // Primary Key
        builder.HasKey(x => x.Id);

        // Name
        builder.Property(x => x.Name)
            .HasMaxLength(150)
            .IsRequired();

        // Code
        builder.Property(x => x.Code)
            .HasMaxLength(10)
            .IsRequired();

        // // IsMain
        // builder.Property(x => x.IsMain)
        //     .IsRequired()
        //     .HasDefaultValue(false);

        // // AverageRating
        // builder.Property(x => x.AverageRating)
        //     .IsRequired()
        //     .HasDefaultValueSql("SELECT * FROM ");


        // // Relationships
        // builder.HasOne<Game>(x=>x.Game)
        // .WithMany(x=>x.GameRegions)
        // .HasForeignKey(x=>x.GameId);

        // CreatedOn
        builder.Property(x => x.CreatedOn)
            // .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'")
            .HasDefaultValue(DateTimeOffset.UtcNow)
            .IsRequired();

        // CreatedByUserId
        builder.Property(x => x.CreatedByUserId)
            .HasMaxLength(100)
            .IsRequired(false);

        // ModifiedOn
        builder.Property(x => x.ModifiedOn)
            .IsRequired(false);

            // ModifiedByUserId
        builder.Property(x => x.ModifiedByUserId)
            .HasMaxLength(100)
            .IsRequired(false);


    }
}
