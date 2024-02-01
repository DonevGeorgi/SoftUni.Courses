namespace MusicHub
{
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context,9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder result = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .ToList()
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.Writer.Name),
                    a.Price

                })
                .OrderByDescending(a => a.Price);

            int songNumber = 1;

            foreach (var album in albums)
            {
                result.AppendLine($"-AlbumName: {album.Name}");
                result.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                result.AppendLine($"-ProducerName: {album.ProducerName}");
                result.AppendLine($"-Songs:");


                foreach (var song in album.Songs)
                {
                    result.AppendLine($"---#{songNumber++}");
                    result.AppendLine($"---SongName: {song.Name}");
                    result.AppendLine($"---Price: {song.Price:f2}");
                    result.AppendLine($"---Writer: {song.Writer.Name}");
                }

                songNumber = 1;
                result.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return result.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder result = new StringBuilder();

            var songs = context.Songs
                .Where(a => a.Duration.TotalSeconds > duration)
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer.Name)
                .ToList();

            int songNumber = 1;

            foreach (var song in songs)
            {
                result.AppendLine($"-Song #{songNumber}");
                result.AppendLine($"---SongName: {song.Name}");
                result.AppendLine($"---Writer: {song.Writer.Name}");

                foreach (var performer in song.SongPerformers
                                         .OrderBy(x => x.Performer.FirstName)
                                         .ThenBy(x => x.Performer.LastName))
                {
                    string fullName = performer.Performer.FirstName + " " + performer.Performer.LastName;
                    result.AppendLine($"---Performer: {fullName}");
                }

                result.AppendLine($"---AlbumProducer: {song.Album.Producer.Name}");
                result.AppendLine($"---Duration: {song.Duration.ToString("c")}");

                songNumber++;
            }

            return result.ToString().TrimEnd();
        }
    }
}
