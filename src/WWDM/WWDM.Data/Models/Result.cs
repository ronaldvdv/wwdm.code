namespace WWDM.Models
{
    public class Result : IEntity
    {
        public virtual Episode Episode { get; set; }
        public int Id { get; set; }
        public string Notes { get; set; }
        public virtual Participant Participant { get; set; }
        public ResultType Type { get; set; }
    }
}