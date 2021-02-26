using GreenDonut;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public class EpisodeBySeasonIdDataLoader : EntityByFieldGroupedDataLoader<int, Episode>
    {
        public EpisodeBySeasonIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory)
            : base(batchScheduler, dbContextFactory, e => e.SeasonId)
        {
        }
    }
}
