using GreenDonut;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public class SeasonByIdDataLoader : EntityByIdDataLoader<Season>
    {
        public SeasonByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory) 
            : base(batchScheduler, dbContextFactory)
        {            
        }
    }
}
