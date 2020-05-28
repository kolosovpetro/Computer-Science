using System.Linq;
using System.Net.Http;
using IdentityAndPostgres.Data;
using IdentityAndPostgres.Models;
using Newtonsoft.Json.Linq;

namespace IdentityAndPostgres.ViewModels
{
    public class MoviesViewModel : MoviesModel
    {
        private readonly RentalContext _rentalContext = new RentalContext();

        public int CopiesCount => AllCopiesNumber();
        public int AvailableCopiesCount => AvailableCopiesNumber();
        public string Plot => GetMoviePlot();
        public string Poster => GetMoviePoster();

        public bool? Available { get; set; }

        private int AllCopiesNumber()
        {
            return _rentalContext.Copies.Count(x => x.MovieId == MovieId);
        }

        private int AvailableCopiesNumber()
        {
            return _rentalContext.Copies.Count(x => x.MovieId == MovieId && (bool)x.Available);
        }

        private string GetMoviePoster()
        {
            const string apiKey = "XXXXXXX";
            var url = $"http://www.omdbapi.com/?apikey={apiKey}&t={Title}&plot=full";
            using var httpClient = new HttpClient();
            var task = httpClient.GetAsync(url);
            task.Wait();
            var result = task.Result;

            if (result.IsSuccessStatusCode)
            {
                var content = result.Content.ReadAsStringAsync();
                content.Wait();
                var jsonString = content.Result;
                var jsonObject = JObject.Parse(jsonString);
                if (jsonObject.ContainsKey("Poster"))
                {
                    return jsonObject["Poster"].ToString();
                }
            }

            return "N/A";
        }

        private string GetMoviePlot()
        {
            const string apiKey = "XXXXXX";
            var url = $"http://www.omdbapi.com/?apikey={apiKey}&t={Title}&plot=full";
            using var httpClient = new HttpClient();
            var task = httpClient.GetAsync(url);
            task.Wait();
            var result = task.Result;

            if (result.IsSuccessStatusCode)
            {
                var content = result.Content.ReadAsStringAsync();
                content.Wait();
                var jsonString = content.Result;
                var jsonObject = JObject.Parse(jsonString);
                if (jsonObject.ContainsKey("Plot"))
                {
                    return jsonObject["Plot"].ToString();
                }
            }

            return "N/A";
        }
    }
}
