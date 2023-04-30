using Boardgames.Common;
using Boardgames.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellersDto
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(ValidationConstants.SellerNameMaxLength)]
        [MinLength(ValidationConstants.SellerNameMinLength)]
        public string Name { get; set; } = null!;

        [JsonProperty("Address")]
        [Required]
        [MaxLength(ValidationConstants.SellerAddressMaxLength)]
        [MinLength(ValidationConstants.SellerAddressMinLength)]
        public string Address { get; set; } = null!;

        [JsonProperty("Country")]
        [Required]
        public string Country { get; set; } = null!;

        [JsonProperty("Website")]
        [Required]
        [RegularExpression(ValidationConstants.SellerWebsiteRegex)]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")]
        public int[] Boardgames{ get; set; }
    }
}
