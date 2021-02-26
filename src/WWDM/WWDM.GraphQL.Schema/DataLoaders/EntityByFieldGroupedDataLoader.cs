using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public abstract class EntityByFieldGroupedDataLoader<TField, TEntity> : GroupedDataLoader<TField, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbContextFactory<WWDMContext> _dbContextFactory;
        private readonly Expression<Func<TEntity, TField>> _field;

        public EntityByFieldGroupedDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory, Expression<Func<TEntity, TField>> field) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
            _field = field;
        }

        protected override async Task<ILookup<TField, TEntity>> LoadGroupedBatchAsync(IReadOnlyList<TField> keys, CancellationToken cancellationToken)
        {            
            await using WWDMContext dbContext = _dbContextFactory.CreateDbContext();
            var predicate = _field.CreatePredicate(keys);
            var result = await dbContext.Set<TEntity>()
                .Where(predicate)
                .ToArrayAsync();
            return result.ToLookup(_field.Compile());
        }
    }
}
