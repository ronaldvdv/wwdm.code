using HotChocolate.Types;
using WWDM.Models;

namespace WWDM.GraphQL.Types
{
    public class ImageType : ObjectType<Image>
    {
        protected override void Configure(IObjectTypeDescriptor<Image> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(im => im.AbsolutePath);
            descriptor.Field("extension").Resolver(_ => "jpg");
        }
    }
}