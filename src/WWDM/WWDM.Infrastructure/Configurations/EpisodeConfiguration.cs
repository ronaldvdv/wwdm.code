using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WWDM.Models.Configurations
{
    internal class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.HasMany(typeof(Image), nameof(Episode.Images)).WithOne(nameof(Image.Episode)).IsRequired();
            builder.HasMany(typeof(Game), nameof(Episode.Games)).WithOne(nameof(Game.Episode)).IsRequired();
            builder.HasOne(typeof(Image), nameof(Episode.Image));
            builder.HasMany(typeof(Result), nameof(Episode.Results)).WithOne(nameof(Result.Episode)).IsRequired();
            builder.HasMany(typeof(Mutation), nameof(Episode.Mutations)).WithOne(nameof(Mutation.Episode)).IsRequired();
            builder.HasMany(typeof(Suspicion), nameof(Episode.Suspicions)).WithOne(nameof(Suspicion.Episode)).IsRequired();
            builder.Ignore(e => e.ActiveParticipants);
            builder.Ignore(e => e.Participants);
        }
    }
}