namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportCreatorDto[] creatorDtos = xmlHelper.Deserialize<ImportCreatorDto[]>(xmlString, "Creators");

            ICollection<Creator> validCreators = new HashSet<Creator>();
            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                ICollection<Boardgame> validBoardgames = new HashSet<Boardgame>();

                foreach (ImportBoardgameDto boardgameDto in creatorDto.Boardgames)
                {

                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame() 
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished= boardgameDto.YearPublished,
                        CategoryType= (CategoryType)boardgameDto.CategoryType,
                        Mechanics= boardgameDto.Mechanics,
                    };

                    validBoardgames.Add(boardgame);
                }

                Creator creator = new Creator()
                { 
                    FirstName= creatorDto.FirstName,
                    LastName= creatorDto.LastName,
                    Boardgames = validBoardgames,
                };

                validCreators.Add(creator);
                sb.AppendLine(String.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportSellersDto[] sellersDtos = JsonConvert.DeserializeObject<ImportSellersDto[]>(jsonString);

            ICollection<Seller> validSellers = new HashSet<Seller>();
            ICollection<int> boardgameIds = context.Boardgames
                .Select(b => b.Id)
                .ToArray();

            foreach (var sellersDto in sellersDtos)
            {
                if (!IsValid(sellersDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellersDto.Name,
                    Address= sellersDto.Address,
                    Country= sellersDto.Country,
                    Website= sellersDto.Website,
                };

                foreach (var boardgameId in sellersDto.Boardgames.Distinct())
                {
                    if (!boardgameIds.Contains(boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        BoardgameId = boardgameId,
                        Seller = seller
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                validSellers.Add(seller);
                sb.AppendLine(String.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
