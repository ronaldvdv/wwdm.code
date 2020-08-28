namespace WWDM.Models
{
    public class GameTag
    {
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        public virtual Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}