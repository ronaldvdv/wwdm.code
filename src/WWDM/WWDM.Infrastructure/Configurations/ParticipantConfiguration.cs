using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WWDM.Models.Configurations
{
    internal class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasMany(typeof(Image), nameof(Participant.Images)).WithOne(nameof(Image.Participant));
            builder.HasOne(typeof(Image), nameof(Participant.Image));
            builder.HasMany(typeof(Result), nameof(Participant.Results)).WithOne(nameof(Result.Participant)).IsRequired();
            builder.HasMany(typeof(Suspicion), nameof(Participant.Suspicions)).WithOne(nameof(Suspicion.Participant)).IsRequired();
            builder.HasMany(typeof(Suspicion), nameof(Participant.Suspecteds)).WithOne(nameof(Suspicion.Suspect)).IsRequired();
            builder.HasMany(typeof(TeamMember), nameof(Participant.TeamMemberships)).WithOne(nameof(TeamMember.Participant)).IsRequired();
            builder.HasMany(typeof(ParticipantLink), nameof(Participant.Links)).WithOne(nameof(ParticipantLink.Participant));
            builder.Ignore(p => p.Episodes);
            builder.Ignore(p => p.ActiveEpisodes);
        }
    }
}