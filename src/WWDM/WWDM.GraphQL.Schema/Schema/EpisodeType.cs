using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Types;
using WWDM.GraphQL.DataLoaders;
using WWDM.Models;

namespace WWDM.GraphQL.Schema
{
    public class EpisodeType : ObjectType<Episode>
    {
        protected override void Configure(IObjectTypeDescriptor<Episode> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(e => e.Games).ResolveWith<EpisodeResolver>(er => er.GetGamesAsync(default!, default!, default!));
            descriptor.Field(e => e.Image).ResolveWith<EpisodeResolver>(er => er.GetImageAsync(default!, default!, default!));
            descriptor.Field(e => e.Season).ResolveWith<EpisodeResolver>(er => er.GetSeasonAsync(default!, default!, default!));
            descriptor.Field("imageFolder").ResolveWith<EpisodeResolver>(er => er.GetImageFolderAsync(default!, default!, default!));
        }

        private class EpisodeResolver
        {
            public async Task<string> GetImageFolderAsync(Episode episode, SeasonByIdDataLoader seasonLoader, CancellationToken cancellationToken)
            {
                var season = await GetSeasonAsync(episode, seasonLoader, cancellationToken);
                return season.Index.ToString("D2") + "e" + episode.Index.ToString("D2");
            }
            
            public Task<Game[]> GetGamesAsync(Episode episode, GameByEpisodeIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return dataLoader.LoadAsync(episode.Id, cancellationToken);
            }

            public Task<Image> GetImageAsync(Episode episode, ImageByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return dataLoader.LoadAsync(episode.ImageId, cancellationToken);
            }

            public Task<Season> GetSeasonAsync(Episode episode, SeasonByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return dataLoader.LoadAsync(episode.SeasonId, cancellationToken);
            }
        }
    }
}