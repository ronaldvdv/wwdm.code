using System.Collections.Generic;

namespace WWDM.Models
{
    public class Location : IEntity
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public int Id { get; set; }
        public int Index { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public bool Route { get; set; }
        public virtual Season Season { get; set; }
    }
}