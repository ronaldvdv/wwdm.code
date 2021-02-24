using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace WWDM.GraphQL
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<WWDMContext>();
        }
    }
}