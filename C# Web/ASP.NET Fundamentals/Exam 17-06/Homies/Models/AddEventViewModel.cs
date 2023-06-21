using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class AddEventViewModel
    {
        public AddEventViewModel()
        {
            this.Types = new HashSet<TypeViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; } 

        [Required]
        public DateTime End { get; set; } 

        [Required]
        [Range(1, int.MaxValue)]
        public int TypeId { get; set; }

        public ICollection<TypeViewModel> Types { get; set; } 
    }
}
