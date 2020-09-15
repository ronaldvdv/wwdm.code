using HotChocolate.Types;
using WWDM.GraphQL.Schema;

namespace WWDM.GraphQL.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(f => f.Hello()).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.GetSeasons(default));
        }
    }
}