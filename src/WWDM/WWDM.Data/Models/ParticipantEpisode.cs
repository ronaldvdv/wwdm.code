using System.Collections.Generic;
using System.Linq;

namespace WWDM.Models
{
    public class ParticipantEpisode
    {
        public readonly IReadOnlyCollection<Result> Results;

        public ParticipantEpisode(Participant participant, Episode episode, bool isActiveBefore)
        {
            Participant = participant;
            Episode = episode;
            IsActiveBefore = isActiveBefore;
            Suspicions = episode.Suspicions.Where(s => s.Participant == participant).ToArray();
            Results = participant.Results.Where(p => p.Episode == episode).ToArray();
        }

        public Episode Episode { get; }
        public bool HasWildcard => HasResult(ResultType.Wildcard);

        public bool IsActive => IsActiveBefore || IsReturning;

        public bool IsActiveAfter => IsActive && !IsLeaving;

        public bool IsActiveBefore { get; }
        public bool IsLeaving => HasResult(ResultType.Exit);
        public bool IsReturning => HasResult(ResultType.Return);
        public Participant Participant { get; }
        public IReadOnlyCollection<Suspicion> Suspicions { get; }

        public bool HasResult(ResultType type)
        {
            return Results.Any(r => r.Type == type);
        }

        internal bool Suspects(Participant p)
        {
            return Suspicions.Any(s => s.Suspect == p);
        }
    }
}