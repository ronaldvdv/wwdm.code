using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WWDM.Models.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasMany(typeof(TeamMember), nameof(Team.Members)).WithOne(nameof(TeamMember.Team)).IsRequired();
            builder.Ignore(t => t.IsFullGroup);
        }
    }
}