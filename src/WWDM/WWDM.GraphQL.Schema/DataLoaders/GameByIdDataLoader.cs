using GreenDonut;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public class GameByIdDataLoader : EntityByIdDataLoader<Game>
    {
        public GameByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory)
            : base(batchScheduler, dbContextFactory)
        {
        }
    }
}
