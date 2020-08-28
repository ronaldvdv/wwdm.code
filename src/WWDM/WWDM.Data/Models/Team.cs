using System.Collections.Generic;
using System.Linq;

namespace WWDM.Models
{
    public class Team : IEntity
    {
        public virtual Game Game { get; set; }
        public int Id { get; set; }

        public bool IsFullGroup
        {
            get
            {
                int active = Game.Episode.ActiveParticipants.Count();
                return active == Members.Count;
            }
        }

        public virtual ICollection<TeamMember> Members { get; set; }
    }
}