using System.Collections.Generic;

namespace WWDM.Models
{
    public class TagGroup : IEntity
    {
        public string Color { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public string Text { get; set; }
    }
}