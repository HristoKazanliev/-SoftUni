using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    using Common;

    public class Boardgame
    {
        public Boardgame()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;

        public double Rating { get; set; }

        [MaxLength(ValidationConstants.BoardgameYearPublishedMaxLength)]
        public int YearPublished { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; } = null!;

        [ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }

        public virtual Creator Creator { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
