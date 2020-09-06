using HotChocolate.Types;
using WWDM.GraphQL.Schema;
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

    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(f => f.Hello()).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.GetSeasons(default));
        }
    }

    public class SeasonType : ObjectType<Season>
    {
        protected override void Configure(IObjectTypeDescriptor<Season> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(s => s.Episodes).ResolveOneToMany<Season, Episode>(e => e.SeasonId);
            descriptor.Field(s => s.Image).ResolveOneToOne<Season, Image>(s => s.ImageId);
        }
    }
}