using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WWDM.Models.Configurations
{
    internal class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasMany(typeof(Episode), nameof(Season.Episodes)).WithOne(nameof(Episode.Season)).IsRequired();
            builder.HasMany(typeof(Participant), nameof(Season.Participants)).WithOne(nameof(Participant.Season)).IsRequired();
            builder.HasMany(typeof(Location), nameof(Season.Locations)).WithOne(nameof(Location.Season)).IsRequired();
        }
    }
}