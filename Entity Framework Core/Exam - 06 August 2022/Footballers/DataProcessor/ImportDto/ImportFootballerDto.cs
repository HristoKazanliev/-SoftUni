using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [XmlElement("Name")]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; } = null!;

        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; } = null!;

        [XmlElement("BestSkillType")]
        public int PositionType { get; set; }

        [XmlElement("PositionType")]
        public int BestSkillType { get; set; }
    }
}
