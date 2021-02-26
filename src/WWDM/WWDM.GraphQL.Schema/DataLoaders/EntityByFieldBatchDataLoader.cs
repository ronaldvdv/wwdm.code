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
    public abstract class EntityByFieldBatchDataLoader<TField, TEntity> : BatchDataLoader<TField, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbContextFactory<WWDMContext> _dbContextFactory;
        private readonly Expression<Func<TEntity, TField>> _field;
        
        public EntityByFieldBatchDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory, Expression<Func<TEntity, TField>> field) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
            _field = field;
        }

        protected override async Task<IReadOnlyDictionary<TField, TEntity>> LoadBatchAsync(IReadOnlyList<TField> keys, CancellationToken cancellationToken)
        {
            await using WWDMContext dbContext = _dbContextFactory.CreateDbContext();
            var predicate = _field.CreatePredicate(keys);
            var result = await dbContext.Set<TEntity>()
                .Where(predicate)
                .ToArrayAsync();
            return result.ToDictionary(_field.Compile());
        }
    }
}
