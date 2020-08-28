using System;
using System.Collections.Generic;
using System.Linq;

namespace WWDM.Models
{
    public class Game : IEntity
    {
        public string Content { get; set; }
        public int? DayEnd { get; set; }
        public int? DayStart { get; set; }
        public string Details { get; set; }
        public virtual Episode Episode { get; set; }
        public int Id { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual Location Location { get; set; }
        public int? MoneyAvailable { get; set; }
        public int? MoneyEarned { get; set; }
        public string Slug => Title.Slugify();
        public string Summary { get; set; }
        public virtual ICollection<GameTag> Tags { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public string Title { get; set; }

        internal void UpdateTags(Tag[] tags)
        {
            if (Tags == null)
            {
                Tags = new List<GameTag>();
            }

            var remove = Tags.Where(gt => !tags.Contains(gt.Tag)).ToArray();
            var add = tags.Where(tag => !Tags.Any(gt => gt.Tag == tag)).ToArray();
            foreach (var gt in remove)
                Tags.Remove(gt);

            foreach (var tag in add)
                Tags.Add(new GameTag { Tag = tag });
        }
    }
}