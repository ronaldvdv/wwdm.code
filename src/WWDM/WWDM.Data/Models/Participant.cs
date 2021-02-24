using System;
using System.Collections.Generic;
using System.Linq;

namespace WWDM.Models
{
    public class Participant : IEntity
    {
        private Dictionary<Episode, ParticipantEpisode> _episodes = null;

        public IEnumerable<Episode> ActiveEpisodes => Episodes.Values.Where(e => e.IsActive).Select(pe => pe.Episode);

        public string Content { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IReadOnlyDictionary<Episode, ParticipantEpisode> Episodes
        {
            get
            {
                if (_episodes == null)
                {
                    _episodes = GetEpisodes().ToDictionary(pe => pe.Episode);
                }
                return _episodes;
            }
        }

        public string FirstName { get; set; }

        public Gender Gender { get; set; } = Gender.Unspecified;
        public int Id { get; set; }
        public virtual Image Image { get; set; }
        public int ImageId { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public string Infix { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<ParticipantLink> Links { get; }
        public string Name => FirstName + (string.IsNullOrWhiteSpace(Infix) ? "" : " " + Infix) + " " + LastName;
        public string PlaceOfBirth { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public Role Role { get; set; } = Role.Unknown;
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public string Slug => FirstName.Slugify();
        public string Summary { get; set; }
        public virtual ICollection<Suspicion> Suspecteds { get; set; }
        public virtual ICollection<Suspicion> Suspicions { get; set; }
        public virtual ICollection<TeamMember> TeamMemberships { get; set; }
        //public ParticipantEpisode this[Episode episode] => Episodes[episode];

        public static string GetRoleName(Role role)
        {
            return role switch
            {
                Role.Mole => "Mol",
                Role.Participant => "Afvaller",
                Role.RunnerUp => "Finalist",
                Role.Winner => "Winnaar",
                Role.Unknown => "Kandidaat",
                _ => "?"
            };
        }

        private IEnumerable<ParticipantEpisode> GetEpisodes()
        {
            bool active = true;
            foreach (var episode in Season.Episodes.OrderBy(e => e.Index))
            {
                var pe = new ParticipantEpisode(this, episode, active);
                active = pe.IsActiveAfter;
                yield return pe;
            }
        }
    }
}