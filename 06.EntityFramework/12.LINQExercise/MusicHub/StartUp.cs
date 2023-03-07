namespace MusicHub;

using System;
using System.Globalization;
using System.Text;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        //DbInitializer.ResetDatabase(context);

        //Test your solutions here

        int producerId = int.Parse(Console.ReadLine());

        Console.WriteLine(ExportAlbumsInfo(context, producerId));
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        StringBuilder sb = new StringBuilder();

        List<Album> albums = context.Albums
            .Where(a => a.ProducerId.HasValue && a.ProducerId == producerId)
            .Include(a => a.Producer)
            .Include(a => a.Songs.OrderByDescending(s => s.Name).ThenBy(s => s.Writer)).ThenInclude(s => s.Writer)
            .ToList()
            .OrderByDescending(a => a.Price)
            .ToList();

        foreach (var a in albums)
        {
            sb
                .AppendLine($"-AlbumName: {a.Name}")
                .AppendLine($"-ReleaseDate: {a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}")
                .AppendLine($"-ProducerName: {a.Producer.Name}")
                .AppendLine($"-Songs:");

            int songNumber = 1;
            foreach (var s in a.Songs)
            {
                sb
                    .AppendLine($"---#{songNumber}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Price: {s.Price:f2}")
                    .AppendLine($"---Writer: {s.Writer.Name}");
                songNumber++;
            }

            sb.AppendLine($"-AlbumPrice: {a.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        throw new NotImplementedException();
    }
}