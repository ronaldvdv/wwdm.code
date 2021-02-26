using System;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.DataLoaders
{
    public class ImageByIdDataLoader : EntityByIdDataLoader<Image>
    {
        public ImageByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<WWDMContext> dbContextFactory)
            : base(batchScheduler, dbContextFactory)
        {
        }        
    }
}
