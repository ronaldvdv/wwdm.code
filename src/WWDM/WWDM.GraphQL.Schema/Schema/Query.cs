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

        public Task<Episode[]> GetEpisodes([Service] WWDMContext context) => context.Episodes.ToArrayAsync();

        public Task<Game[]> GetGames([Service] WWDMContext context) => context.Games.ToArrayAsync();

        public Task<Participant[]> GetParticipants([Service] WWDMContext context) => context.Participants.ToArrayAsync();

        public string Hello() => "world";

        public Task<Season> Season(int id, [Service] WWDMContext context) => context.Seasons.FirstOrDefaultAsync(s => s.Id == id);

        public Task<Game> Game(int id, [Service] WWDMContext context) => context.Games.FirstOrDefaultAsync(s => s.Id == id);

        public Task<Participant> Participant(int id, [Service] WWDMContext context) => context.Participants.FirstOrDefaultAsync(s => s.Id == id);
    }
}