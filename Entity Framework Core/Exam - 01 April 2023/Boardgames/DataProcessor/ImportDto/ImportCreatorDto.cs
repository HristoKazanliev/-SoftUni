using Boardgames.Common;
using Boardgames.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [XmlElement("FirstName")]
        [Required]
        [MaxLength(ValidationConstants.CreatorNameMaxLength)]
        [MinLength(ValidationConstants.CreatorNameMinLength)]
        public string FirstName { get; set; } = null!;

        [XmlElement("LastName")]
        [Required]
        [MaxLength(ValidationConstants.CreatorNameMaxLength)]
        [MinLength(ValidationConstants.CreatorNameMinLength)]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public ImportBoardgameDto[] Boardgames { get; set; }
    }
}
