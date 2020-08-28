using System.Collections.Generic;

namespace WWDM.Models
{
    public class Website : IEntity
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}