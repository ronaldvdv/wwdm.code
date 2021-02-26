using GreenDonut;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public class EpisodeByIdDataLoader : EntityByIdDataLoader<Episode>
    {
        public EpisodeByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory)
            : base(batchScheduler, dbContextFactory)
        {
        }
    }
}
