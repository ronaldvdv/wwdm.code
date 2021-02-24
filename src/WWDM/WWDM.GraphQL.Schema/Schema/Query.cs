using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using WWDM.GraphQL.DataLoaders;
using WWDM.Models;

namespace WWDM.GraphQL.Schema
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Season>> GetSeasons([ScopedService] WWDMContext context) => context.Seasons.ToListAsync();

        public Task<Season> GetSeasonAsync(int id, SeasonByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}