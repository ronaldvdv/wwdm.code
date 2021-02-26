using GreenDonut;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public abstract class EntityByIdDataLoader<TEntity> : EntityByFieldBatchDataLoader<int, TEntity>
        where TEntity : class, IEntity
    {
        protected EntityByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory) 
            : base(batchScheduler, dbContextFactory, e => e.Id)
        {
        }
    }
}
