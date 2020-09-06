using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using WWDM.Models;

namespace WWDM.GraphQL.Schema
{
    public class Query
    {
        public Task<Episode> Episode(int id, [Service] WWDMContext context) => context.Episodes.FirstOrDefaultAsync(e => e.Id == id);

        public Task<Season[]> GetSeasons([Service] WWDMContext context) => context.Seasons.ToArrayAsync();

        public string Hello() => "world";

        public Task<Season> Season(int id, [Service] WWDMContext context) => context.Seasons.FirstOrDefaultAsync(s => s.Id == id);
    }
}