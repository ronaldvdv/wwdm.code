namespace WWDM.Models
{
    public class TeamMember : IEntity
    {
        public int Id { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual Team Team { get; set; }
    }
}