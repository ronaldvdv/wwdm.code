using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Types;
using WWDM.GraphQL.DataLoaders;
using WWDM.Models;

namespace WWDM.GraphQL.Schema
{
    public class SeasonType : ObjectType<Season>
    {
        protected override void Configure(IObjectTypeDescriptor<Season> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(s => s.Episodes).ResolveWith<SeasonResolver>(sr => sr.GetEpisodesAsync(default!, default!, default!)).UseDbContext<WWDMContext>();
            descriptor.Field(s => s.Image).ResolveWith<SeasonResolver>(er => er.GetImageAsync(default!, default!, default!));
        }

        private class SeasonResolver
        {
            public Task<Episode[]> GetEpisodesAsync(Season season, EpisodeBySeasonIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return dataLoader.LoadAsync(season.Id, cancellationToken);
            }
            
            public Task<Image> GetImageAsync(Season season, ImageByIdDataLoader dataLoader, CancellationToken cancellationToken)
            {
                return dataLoader.LoadAsync(season.ImageId, cancellationToken);
            }
        }
    }
}