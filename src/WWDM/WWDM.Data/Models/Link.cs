namespace WWDM.Models
{
    public class Link : IEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public virtual Website Website { get; set; }
    }
}