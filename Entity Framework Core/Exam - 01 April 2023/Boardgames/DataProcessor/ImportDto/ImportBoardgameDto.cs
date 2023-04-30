using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
        [MinLength(ValidationConstants.BoardgameNameMinLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Rating")]
        [Range(ValidationConstants.BoardgameRatingMinLength, ValidationConstants.BoardgameRatingMaxLength)]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        [Range(ValidationConstants.BoardgameYearPublishedMinLength, ValidationConstants.BoardgameYearPublishedMaxLength)]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        [Required]
        [Range(ValidationConstants.BoardgameCategoryTypeMinLength, ValidationConstants.BoardgameCategoryTypeMaxLength)]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        [Required]
        public string Mechanics { get; set; } = null!;
    }
}
