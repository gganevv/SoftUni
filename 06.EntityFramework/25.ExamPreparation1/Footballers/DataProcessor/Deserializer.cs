namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Footballers.Utilities;
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

            var coachesDtos = xmlHelper.Deserialize<ImportCoachDto[]>(xmlString, "Coaches");
            var coaches = new HashSet<Coach>();

            foreach (var coachDto in coachesDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality
                };

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime validStartDate;
                    bool isStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validStartDate);

                    DateTime validEndDate;
                    bool isEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validEndDate);

                    if (!isStartDateValid || !isEndDateValid || validEndDate < validStartDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = validStartDate,
                        ContractEndDate = validEndDate,
                        PositionType = (PositionType)footballerDto.PositionType,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        Coach = coach
                    };

                    coach.Footballers.Add(footballer);
                }

                coaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count()));
            }

            context.AddRange(coaches);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);
            var teams = new HashSet<Team>();
            List<int> takenFootballers = new List<int>();
            List<int> existingFootballers = context.Footballers
                .Select(f => f.Id) 
                .ToList();

            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies
                };
                
                foreach (var footballer in teamDto.Footballers)
                {
                    if (!takenFootballers.Contains(footballer) && existingFootballers.Contains(footballer))
                    {
                        team.TeamsFootballers.Add(new TeamFootballer()
                        {
                            FootballerId = footballer,
                            Team = team
                        });
                        takenFootballers.Add(footballer);
                    }
                }

                teams.Add(team);
            }

            context.AddRange(teams);
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
