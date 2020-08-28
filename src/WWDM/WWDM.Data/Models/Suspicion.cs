namespace WWDM.Models
{
    public class Suspicion : IEntity
    {
        public virtual Episode Episode { get; set; }
        public int Id { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual Participant Suspect { get; set; }
    }
}