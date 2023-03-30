namespace Trucks.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using Data;
using Trucks.Data.Models;
using Trucks.DataProcessor.ImportDto;
using Trucks.Util;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedDespatcher
        = "Successfully imported despatcher - {0} with {1} trucks.";

    private const string SuccessfullyImportedClient
        = "Successfully imported client - {0} with {1} trucks.";

    public static string ImportDespatcher(TrucksContext context, string xmlString)
    {
        XmlHelper xmlHelper = new XmlHelper();
        StringBuilder sb = new StringBuilder();
        IMapper mapper = CreateMapper();

        var despatcherDtos = xmlHelper.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");
        var despatchers = new HashSet<Despatcher>();

        foreach (var despatcherDto in despatcherDtos)
        {
            if (!IsValid(despatcherDto) )
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Despatcher despatcher = mapper.Map<Despatcher>(despatcherDto);
            despatchers.Add(despatcher);

            foreach (var truckDto in despatcherDto.Trucks)
            {
                if (!IsValid(truckDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Truck truck = mapper.Map<Truck>(truckDto);
                despatcher.Trucks.Add(truck);
            }

            sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
        }

        return sb.ToString().TrimEnd();
    }
    public static string ImportClient(TrucksContext context, string jsonString)
    {
        throw new NotImplementedException();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TrucksProfile>();
        }));
}