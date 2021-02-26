using GreenDonut;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public class GameByEpisodeIdDataLoader : EntityByFieldGroupedDataLoader<int, Game>
    {
        public GameByEpisodeIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory)
            : base(batchScheduler, dbContextFactory, g => g.EpisodeId)
        {
        }
    }
}
