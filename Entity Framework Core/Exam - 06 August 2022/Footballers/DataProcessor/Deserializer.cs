namespace Footballers.DataProcessor
{
    using CarDealer;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCoachDto[] coachDtos = xmlHelper.Deserialize<ImportCoachDto[]>(xmlString, "Coaches");

            ICollection<Coach> validCoaches = new HashSet<Coach>();
            foreach (var coachDto in coachDtos)
            {
                ICollection<Footballer> validFootballers = new HashSet<Footballer>();

                if (string.IsNullOrEmpty(coachDto.Name) || string.IsNullOrEmpty(coachDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };

                if (!IsValid(coach))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (string.IsNullOrEmpty(footballerDto.ContractStartDate) || string.IsNullOrEmpty(footballerDto.ContractEndDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime start = DateTime.ParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime end = DateTime.ParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (string.IsNullOrEmpty(footballerDto.Name) || start > end)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = start,
                        ContractEndDate = end,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType,

                    };

                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validFootballers.Add(footballer);
                }

                coach.Footballers = validFootballers;
                validCoaches.Add(coach);

                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            ICollection<Team> validTeams = new HashSet<Team>();

            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto) || string.IsNullOrEmpty(teamDto.Name) || string.IsNullOrEmpty(teamDto.Nationality) || string.IsNullOrEmpty(teamDto.Trophies) || int.Parse(teamDto.Trophies) == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = int.Parse(teamDto.Trophies),
                };

                foreach (var footballerId in teamDto.Footballers.Distinct())
                {
                    Footballer footballer = context.Footballers.Find(footballerId);

                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = footballer
                    });
                }

                validTeams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
