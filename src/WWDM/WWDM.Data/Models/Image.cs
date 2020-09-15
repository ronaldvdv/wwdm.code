using System;
using System.IO;

namespace WWDM.Models
{
    public class Image : IEntity
    {
        public string AbsolutePath => Path.Combine(Episode.ImageFolder, Filename);
        public virtual Episode Episode { get; set; }
        public string Filename { get; set; }
        public virtual Game Game { get; set; }

        public int Height { get; set; }

        public int Id { get; set; }

        public virtual Participant Participant { get; set; }

        public TimeSpan Timestamp { get; set; }

        public int Width { get; set; }
    }
}