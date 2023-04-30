namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportCreatorDto[] creatorDtos = context.Creators
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportCreatorDto()
                {
                   Name = c.FirstName + " " + c.LastName,
                   BoardgameCount = c.Boardgames.Count(),
                   Boardgames = c.Boardgames
                                .Select(b => new ExportBoardgameDto()
                                {
                                    Name = b.Name,
                                    YearPublished= b.YearPublished,
                                })
                                .OrderBy(b => b.Name)
                                .ToArray()
                })
                .OrderByDescending(c => c.BoardgameCount)
                .ThenBy(c => c.Name)
                .ToArray();

            return xmlHelper.Serialize(creatorDtos, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Include(s => s.BoardgamesSellers)
                .ThenInclude(b => b.Boardgame)
                .AsNoTracking()
                .ToArray()
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(s => new 
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                                .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                           .Select(bs => new 
                               {
                                    Name = bs.Boardgame.Name,
                                    Rating = bs.Boardgame.Rating,
                                    Mechanics = bs.Boardgame.Mechanics,
                                    Category = bs.Boardgame.CategoryType.ToString()
                               })
                           .OrderByDescending(b => b.Rating)
                           .ThenBy(b => b.Name)
                           .ToArray()  
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}