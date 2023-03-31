namespace Footballers.DataProcessor
{
    using CarDealer;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var coachesDto = context.Coaches
                .Where(c => c.Footballers.Any())
                .Select(c => new ExportCoachDto()
                {
                    Name= c.Name,
                    FootballersCount = c.Footballers.Count,
                    Footballers = c.Footballers.Select(f => new ExportCoachFootballerDto()
                                    { 
                                        Name = f.Name,
                                        Position = f.PositionType.ToString()
                                    })
                                    .OrderBy(f => f.Name)
                                    .ToArray()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.Name)
                .ToArray();

            return xmlHelper.Serialize<ExportCoachDto[]>(coachesDto, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                 .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                 .Select(t => new ExportTeamDto()
                 {
                     Name = t.Name,
                     Footballers = t.TeamsFootballers.Where(f => f.Footballer.ContractStartDate >= date)
                                                     .OrderByDescending(f => f.Footballer.ContractEndDate)
                                                     .ThenBy(f => f.Footballer.Name)
                                                     .Select(f => new ExportFootballerDto
                                                     {
                                                         FootballerName = f.Footballer.Name,
                                                         ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                                                         ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                                                         BestSkillType = f.Footballer.BestSkillType.ToString(),
                                                         PositionType = f.Footballer.PositionType.ToString()
                                                     })
                                                     .ToArray()

                 })
                 .OrderByDescending(t => t.Footballers.Count())
                 .ThenBy(t => t.Name)
                 .Take(5)
                 .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
