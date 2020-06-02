using System.Linq;
using System.Net.Http;
using IdentityAndPostgres.Infrastructure;
using IdentityAndPostgres.Models;
using IdentityAndPostgres.Repositories;
using Newtonsoft.Json.Linq;

namespace IdentityAndPostgres.ViewModels
{
    public class MoviesViewModel : MoviesModel
    {
        private readonly CopiesRepository _copiesRepository = new CopiesRepository(new DbFactory());

        public int CopiesCount => AllCopiesNumber();
        public int AvailableCopiesCount => AvailableCopiesNumber();
        public string Plot => GetMoviePlot();
        public string Poster => GetMoviePoster();

        public bool? Available { get; set; }

        private int AllCopiesNumber()
        {
            return _copiesRepository
                .GetAll()
                .Count(x => x.MovieId == MovieId);
        }

        private int AvailableCopiesNumber()
        {
            return _copiesRepository
                .GetAll()
                .Count(x => x.Available != null && x.MovieId == MovieId && (bool)x.Available);
        }

        private string GetMoviePlot()
        {
            var result = MovieData();
            var jsonObject = JsonMovieObject(result);
            if (result.IsSuccessStatusCode && jsonObject.ContainsKey("Plot"))
                return jsonObject["Plot"].ToString();

            return "N/A";
        }

        private string GetMoviePoster()
        {
            var result = MovieData();
            var jsonObject = JsonMovieObject(result);
            if (result.IsSuccessStatusCode && jsonObject.ContainsKey("Poster"))
                return jsonObject["Poster"].ToString();

            return "N/A";
        }

        private HttpResponseMessage MovieData()
        {
            const string apiKey = "XXX";
            var url = $"http://www.omdbapi.com/?apikey={apiKey}&t={Title}&plot=full";
            using var httpClient = new HttpClient();
            var task = httpClient.GetAsync(url);
            task.Wait();
            var result = task.Result;
            return result;
        }

        private static JObject JsonMovieObject(HttpResponseMessage result)
        {
            var content = result.Content.ReadAsStringAsync();
            content.Wait();
            var jsonString = content.Result;
            var jsonObject = JObject.Parse(jsonString);
            return jsonObject;
        }
    }
}
