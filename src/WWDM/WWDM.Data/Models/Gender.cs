using System.ComponentModel.DataAnnotations;

namespace WWDM.Models
{
    public enum Gender
    {
        [Display(Name = "Onbekend/Overig")]
        Unspecified = 0,

        [Display(Name = "Man")]
        Male = 1,

        [Display(Name = "Vrouw")]
        Female = 2
    }
}