using System.ComponentModel.DataAnnotations;

namespace WWDM.Models
{
    public enum Role
    {
        [Display(Name = "Winnaar")]
        Winner,

        [Display(Name = "Finalist")]
        RunnerUp,

        [Display(Name = "Mol")]
        Mole,

        [Display(Name = "Kandidaat")]
        Participant,

        [Display(Name = "Onbekend")]
        Unknown
    }
}