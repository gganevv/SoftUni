namespace Boardgames.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;

using AutoMapper;
using Newtonsoft.Json;

using Boardgames.Data;
using Boardgames.Data.Models;
using Boardgames.DataProcessor.ImportDto;
using Boardgames.Util;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCreator
        = "Successfully imported creator – {0} {1} with {2} boardgames.";

    private const string SuccessfullyImportedSeller
        = "Successfully imported seller - {0} with {1} boardgames.";

    public static string ImportCreators(BoardgamesContext context, string xmlString)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        var creatorsDtos = xmlHelper.Deserialize<ImportCreatorDto[]>(xmlString, "Creators");

        StringBuilder sb = new StringBuilder();
        var creators = new HashSet<Creator>();

        foreach (var creatorDto in creatorsDtos)
        {
            if (!IsValid(creatorDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Creator creator = mapper.Map<Creator>(creatorDto);
            creators.Add(creator);

            foreach (var boardgameDto in creatorDto.BoardgameDtos)
            {
                if (!IsValid(boardgameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Boardgame boardgame = mapper.Map<Boardgame>(boardgameDto);
                creator.Boardgames.Add(boardgame);
            }

            sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count()));
        }

        context.Creators.AddRange(creators);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    public static string ImportSellers(BoardgamesContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();
        IMapper mapper = CreateMapper();

        var sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);
        var sellers = new HashSet<Seller>();

        var boardgamesIds = context.Boardgames
            .Select(b => b.Id).ToArray();

        foreach (var sellerDto in sellerDtos)
        {
            if (!IsValid(sellerDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Seller seller = mapper.Map<Seller>(sellerDto);
            sellers.Add(seller);

            foreach (var boardGame in sellerDto.Boardgames.Distinct())
            {
                if (!boardgamesIds.Contains(boardGame))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                BoardgameSeller boardgameSeller = new BoardgameSeller()
                {
                    Seller = seller,
                    BoardgameId = boardGame
                };

                seller.BoardgamesSellers.Add(boardgameSeller);
            }

            sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count()));
        }

        context.Sellers.AddRange(sellers);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
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
            cfg.AddProfile<BoardgamesProfile>();
        }));
}
