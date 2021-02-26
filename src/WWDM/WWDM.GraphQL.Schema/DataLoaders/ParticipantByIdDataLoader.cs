using GreenDonut;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public class ParticipantByIdDataLoader : EntityByIdDataLoader<Participant>
    {
        public ParticipantByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory)
            : base(batchScheduler, dbContextFactory)
        {
        }
    }
}
