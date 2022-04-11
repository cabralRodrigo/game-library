using GameLibrary.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace GameLibrary.Data.Configuration
{
    public class GameConfiguration : ValueGenerator<GameId>, IEntityTypeConfiguration<Game>
    {
        public override bool GeneratesTemporaryValues => true;

        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");
            builder.HasKey(s => s.Id)
                   .HasName("PK_Game");

            builder.Property(s => s.Id)
                   .IsRequired()
                   .HasColumnName("Id")
                   .HasConversion<GameId.EfCoreValueConverter>()
                   .HasValueGenerator<GameConfiguration>()
                   .ValueGeneratedOnAdd();
        }

        public override GameId Next(EntityEntry entry) => default;
    }
}