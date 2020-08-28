using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.Schema
{
    public class Query
    {
        public Task<Season[]> GetSeasons([Service] WWDMContext context) => context.Seasons.ToArrayAsync();

        public string Hello() => "world";
    }
}