using Boardgames.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        public Creator()
        {
            this.Boardgames = new HashSet<Boardgame>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CreatorNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.CreatorNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Boardgame> Boardgames { get; set; }
    }
}
