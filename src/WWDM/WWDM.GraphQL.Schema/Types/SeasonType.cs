using HotChocolate.Types;
using WWDM.Models;

namespace WWDM.GraphQL.Types
{
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