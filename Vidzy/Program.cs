
using System;
using System.Linq;

namespace LINQ_Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new VidzyContext();

            //var actionMovies = dbContext.Videos
            //    .Where(v => v.GenreId == 2)
            //    .OrderBy(v => v.Name);

            //foreach(var video in actionMovies)
            //    Console.WriteLine(video.Name.ToString());

            //var goldDramaMovies = dbContext.Videos
            //    .Where(v => v.Classification == Classification.Gold && v.Genre.Name == "Drama")
            //    .OrderByDescending(v => v.ReleaseDate);

            //foreach(var video in goldDramaMovies)
            //    Console.WriteLine(video.Name);

            //var anonObject = dbContext.Videos
            //    .Select(v => new { MovieName = v.Name, GenreName = v.Genre.Name });

            //foreach(var video in anonObject)
            //    Console.WriteLine(video.MovieName);

            //var classificationGroup = dbContext.Videos
            //    .Select(v => new { MovieName = v.Name, ClassificationName = v.Classification })
            //    .GroupBy(v => v.ClassificationName);

            //foreach (var group in classificationGroup)
            //{
            //    Console.WriteLine("Classification: " + group.Key);

            //    foreach (var video in group)
            //        Console.WriteLine("\t" + video.MovieName);
            //}

            //var countOfClassifications = dbContext.Videos
            //    .GroupBy(v => v.Classification)
            //    .Select(g => new
            //    {
            //        Name = g.Key.ToString(),
            //        Count = g.Count()
            //    })
            //    .OrderBy(c => c.Name);

            //foreach (var c in countOfClassifications)
            //    Console.WriteLine("{0} ({1})", c.Name, c.Count);

            var groupGenres = dbContext.Genres
                .GroupJoin(dbContext.Videos, g => g.Id, v => v.GenreId, (genre, video) => new
                {
                    Name = genre.Name,
                    VideoCount = video.Count()
                })
                .OrderByDescending(gj => gj.VideoCount);

            foreach(var g in groupGenres)
                Console.WriteLine("{0} ({1})", g.Name, g.VideoCount);


            Console.ReadLine(); 
        }
    }
}
