using System.ComponentModel.DataAnnotations;

namespace WWDM.Models
{
    public class Mutation : IEntity
    {
        public int Amount { get; set; }

        public virtual Episode Episode { get; set; }
        public int Id { get; set; }
        public string Notes { get; set; }
    }
}