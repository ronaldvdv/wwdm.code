using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WWDM.Models.Configurations
{
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasMany(typeof(Image), nameof(Game.Images)).WithOne(nameof(Image.Game));
            builder.HasOne(typeof(Image), nameof(Game.Image));
            builder.HasMany(typeof(GameTag), nameof(Game.Tags)).WithOne(nameof(GameTag.Game)).IsRequired();
            builder.HasMany(typeof(Team), nameof(Game.Teams)).WithOne(nameof(Team.Game)).IsRequired();
        }
    }
}