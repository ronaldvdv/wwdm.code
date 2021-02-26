using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Types;
using WWDM.GraphQL.DataLoaders;
using WWDM.Models;

namespace WWDM.GraphQL.Schema
{
    public class GameType : ObjectType<Game>
    {
        protected override void Configure(IObjectTypeDescriptor<Game> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(e => e.Image).ResolveWith<GameResolver>(er => er.GetImageAsync(default!, default!, default!));
        }

        private class GameResolver
        {
            public Task<Image> GetImageAsync(Game game, ImageByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return dataLoader.LoadAsync(game.ImageId, cancellationToken);
            }
        }
    }
}