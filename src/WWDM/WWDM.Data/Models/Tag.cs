using System.Collections.Generic;

namespace WWDM.Models
{
    public class Tag : IEntity
    {
        public string Description { get; set; }
        public virtual ICollection<GameTag> Games { get; set; }
        public virtual TagGroup Group { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}