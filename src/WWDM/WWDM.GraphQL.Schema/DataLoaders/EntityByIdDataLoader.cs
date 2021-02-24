using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public abstract class EntityByIdDataLoader<TEntity> : BatchDataLoader<int, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbContextFactory<WWDMContext> _dbContextFactory;

        public EntityByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, TEntity>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using WWDMContext dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.Set<TEntity>()
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
