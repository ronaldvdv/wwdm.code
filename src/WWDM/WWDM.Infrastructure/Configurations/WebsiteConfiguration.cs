using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WWDM.Models.Configurations
{
    internal class WebsiteConfiguration : IEntityTypeConfiguration<Website>
    {
        public void Configure(EntityTypeBuilder<Website> builder)
        {
            builder.HasMany(typeof(Link), nameof(Website.Links)).WithOne(nameof(Link.Website)).OnDelete(DeleteBehavior.Cascade);
        }
    }
}