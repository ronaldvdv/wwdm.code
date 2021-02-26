using System.IO;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Types;
using WWDM.GraphQL.DataLoaders;
using WWDM.Models;

namespace WWDM.GraphQL.Schema
{
    public class ImageType : ObjectType<Image>
    {
        protected override void Configure(IObjectTypeDescriptor<Image> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field("absolutePath").ResolveWith<ImageResolver>(ir => ir.GetAbsolutePathAsync(default!, default!, default!));
            descriptor.Field("extension").Resolver(_ => "jpg");
            descriptor.Field(im => im.Episode).ResolveWith<ImageResolver>(er => er.GetEpisodeAsync(default!, default!, default!));
        }

        private class ImageResolver
        {
            public Task<Episode> GetEpisodeAsync(Image image, EpisodeByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return dataLoader.LoadAsync(image.EpisodeId, cancellationToken);
            }

            public async Task<string> GetAbsolutePathAsync(Image image, EpisodeByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                var episode = await GetEpisodeAsync(image, dataLoader, cancellationToken);
                return Path.Combine(episode.ImageFolder, image.Filename);
            }
        }
    }
}