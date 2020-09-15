using HotChocolate.Types;
using WWDM.Models;

namespace WWDM.GraphQL.Types
{
    public class EpisodeType : ObjectType<Episode>
    {
        protected override void Configure(IObjectTypeDescriptor<Episode> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(e => e.Season).ResolveOneToOne<Episode, Season>(e => e.SeasonId);
            descriptor.Field(e => e.Image).ResolveOneToOne<Episode, Image>(e => e.ImageId);
        }
    }
}