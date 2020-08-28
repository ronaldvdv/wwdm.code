using System;
using System.Collections.Generic;
using System.Linq;

namespace WWDM.Models
{
    public class Episode : IEntity
    {
        private readonly Lazy<int> _moneyEnd;
        private readonly Lazy<int> _moneyStart;
        private readonly Lazy<Episode> _next;
        private Dictionary<Participant, ParticipantEpisode> _participants = null;

        private Lazy<Episode> _previous;

        public Episode()
        {
            _moneyEnd = new Lazy<int>(GetMoneyEnd);
            _moneyStart = new Lazy<int>(GetMoneyStart);
            _next = new Lazy<Episode>(GetNext);
            _previous = new Lazy<Episode>(GetPrevious);
        }

        public IEnumerable<Participant> ActiveParticipants => Participants.Values.Where(pe => pe.IsActive).Select(pe => pe.Participant);

        public DateTime Aired { get; set; }

        public string Code => $"S{Season.Index:D2}E{Index:D2}";

        public string Content { get; set; }

        public int? DayEnd { get; set; }

        public int? DayStart { get; set; }

        public int? FirstLocationIndex => Games != null && Games.Any(g => g.Location != null) ? (int?)Games.Where(g => g.Location != null).Min(g => g.Location.Index) : null;

        public virtual ICollection<Game> Games { get; set; }

        public int Id { get; set; }

        public virtual Image Image { get; set; }

        public string ImageFolder => "nl_s" + Season.Index.ToString("D2") + "e" + Index.ToString("D2");

        public int ImageId { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public int Index { get; set; }

        public int? KdhAbs { get; set; }

        public decimal? KdhPerc { get; set; }

        public decimal? KtaPerc { get; set; }

        public int? LastLocationIndex => Games != null && Games.Any(g => g.Location != null) ? (int?)Games.Where(g => g.Location != null).Max(g => g.Location.Index) : null;

        public int MoneyAvailable => Games.Where(g => g.MoneyAvailable.HasValue).Sum(g => g.MoneyAvailable.Value);
        public int MoneyEarned => Games.Where(g => g.MoneyEarned.HasValue).Sum(g => g.MoneyEarned.Value);
        public int MoneyEnd => _moneyEnd.Value;
        public int MoneyMutations => Mutations.Sum(m => m.Amount);
        public int MoneyStart => _moneyStart.Value;
        public virtual ICollection<Mutation> Mutations { get; set; }

        public Episode Next => _next.Value;

        public IReadOnlyDictionary<Participant, ParticipantEpisode> Participants
        {
            get
            {
                if (_participants == null)
                {
                    _participants = Season.Participants.ToDictionary(p => p, p => p.Episodes[this]);
                }
                return _participants;
            }
        }

        public Episode Previous => _previous.Value;

        public virtual ICollection<Result> Results { get; set; }

        public virtual Season Season { get; set; }

        public int SeasonId { get; set; }
        public string Summary { get; set; }

        public virtual ICollection<Suspicion> Suspicions { get; set; }

        public string Title { get; set; }
        //public ParticipantEpisode this[Participant participant] => Participants[participant];

        private int GetMoneyEnd()
        {
            return MoneyStart + MoneyEarned + MoneyMutations;
        }

        private int GetMoneyStart()
        {
            return Previous != null ? Previous.MoneyEnd : 0;
        }

        private Episode GetNext()
        {
            return Index < Season.Episodes.Count ? Season.Episodes.FirstOrDefault(e => e.Index == Index + 1) : null;
        }

        private Episode GetPrevious()
        {
            return Index > 1 ? Season.Episodes.FirstOrDefault(e => e.Index == Index - 1) : null;
        }
    }
}