using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WWDM.Models
{
    public class Season : IEntity
    {
        [Display(Name = "Omroep")]
        public string Broadcaster { get; set; }

        public string Content { get; set; }

        [Display(Name = "Munteenheid")]
        public string Currency { get; set; }

        [Display(Name = "Afleveringen")]
        public virtual ICollection<Episode> Episodes { get; set; }

        [Display(Name = "Vlagcode")]
        public string Flag { get; set; }

        [Display(Name = "Uniek ID")]
        public int Id { get; set; }

        [Display(Name = "Afbeelding")]
        public virtual Image Image { get; set; }

        public int ImageId { get; set; }

        [Display(Name = "Index")]
        public int Index { get; set; }

        [Display(Name = "Locaties")]
        public virtual ICollection<Location> Locations { get; set; }

        [Display(Name = "Deelnemers")]
        public virtual ICollection<Participant> Participants { get; set; }

        [Display(Name = "Presentator")]
        public string Presenter { get; set; }

        [Display(Name = "Producent")]
        public string Producer { get; set; }

        [Display(Name = "Landen")]
        public string RecordingCountries { get; set; }

        public string Summary { get; set; }
    }
}