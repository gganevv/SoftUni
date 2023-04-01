namespace Boardgames.DataProcessor;

using Newtonsoft.Json;

using Boardgames.Data;
using Boardgames.DataProcessor.ExportDto;
using Boardgames.Util;

public class Serializer
{
    public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();

        var creators = context.Creators
            .Where(c => c.Boardgames.Count > 0)
            .Select(c => new ExportCreatorDto
            {
                BoardgamesCount = c.Boardgames.Count,
                CreatorName = c.FirstName + " " + c.LastName,
                Boardgames = c.Boardgames
                    .Select(b => new ExportBoardgameDto
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished
                    })
                    .OrderBy(b => b.BoardgameName)
                    .ToArray()

            })
            .OrderByDescending(c => c.BoardgamesCount)
            .ThenBy(c => c.CreatorName)
            .ToArray();

        return xmlHelper.Serialize<ExportCreatorDto[]>(creators, "Creators");
    }

    public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
    {
        var sellers = context.Sellers
            .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
            .Select(s => new
            {
                s.Name,
                s.Website,
                Boardgames = s.BoardgamesSellers
                .OrderByDescending(b => b.Boardgame.Rating)
                .ThenBy(b => b.Boardgame.Name)
                .Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
                    .Select(b => new
                    {
                        b.Boardgame.Name,
                        b.Boardgame.Rating,
                        b.Boardgame.Mechanics,
                        Category = b.Boardgame.CategoryType.ToString()
                    })
                    .ToArray()
            })
            .OrderByDescending(s => s.Boardgames.Count())
            .ThenBy(s => s.Name)
            .Take(5)
            .ToArray();


        return JsonConvert.SerializeObject(sellers, Formatting.Indented);
    }
}