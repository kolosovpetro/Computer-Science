using System;
using System.Globalization;
using System.Linq;
using DVDRentalStore.Infrastructure;
using DVDRentalStore.Models;
using DVDRentalStore.Repositories;
using Microsoft.AspNetCore.Http;

namespace DVDRentalStore.Services
{
    public class AdminServices
    {
        private readonly CopiesRepository _copiesRepository;
        private readonly ClientsRepository _clientsRepository;
        private readonly RentalsRepository _rentalsRepository;
        private readonly MoviesRepository _moviesRepository;
        private readonly EmployeesRepository _employeesRepository;

        public AdminServices()
        {
            _copiesRepository = new CopiesRepository(new DbFactory());
            _clientsRepository = new ClientsRepository(new DbFactory());
            _rentalsRepository = new RentalsRepository(new DbFactory());
            _moviesRepository = new MoviesRepository(new DbFactory());
            _employeesRepository = new EmployeesRepository(new DbFactory());
        }

        // admin sign in view model
        public EmployeesModel AdminSignInModel(IFormCollection collection)
        {
            var username = collection["FirstName"].ToString();
            var password = collection["LastName"].ToString();

            var admin = _employeesRepository
                .Get(x => x.FirstName == username && x.LastName == password);
            return admin;
        }

        // admin dashboard view model
        public EmployeesModel AdminDashboardModel(int id)
        {
            var admin = _employeesRepository.Get(x => x.EmployeeId == id);
            return admin;
        }

        // add client auxiliary methods
        public ClientsModel AddClientModel(IFormCollection collection)
        {
            var id = _clientsRepository.GetAll().Max(x => x.ClientId) + 1;
            var firstname = collection["FirstName"].ToString();
            var lastname = collection["LastName"].ToString();
            var birthday = Convert.ToDateTime(collection["Birthday"]);

            var client = new ClientsModel
            {
                ClientId = id,
                FirstName = firstname,
                LastName = lastname,
                Birthday = birthday
            };
            return client;
        }

        public void SaveClientInDatabase(ClientsModel client)
        {
            _clientsRepository.Add(client);
            _clientsRepository.Save();
        }

        // edit client
        public ClientsModel EditClientModel(int id)
        {
            var client = _clientsRepository.GetById(id);
            return client;
        }

        public void EditAndSaveClient(int id, IFormCollection collection)
        {
            var client = _clientsRepository.GetById(id);
            var firstname = collection["FirstName"].ToString();
            var lastname = collection["LastName"].ToString();
            var birthday = Convert.ToDateTime(collection["Birthday"]);

            client.FirstName = firstname;
            client.LastName = lastname;
            client.Birthday = birthday;
            _clientsRepository.Update(client);
            _clientsRepository.Save();
        }

        // list of movies model
        public IOrderedEnumerable<MoviesModel> ListOfMoviesModel()
        {
            var movies = _moviesRepository.GetAll()
                .OrderBy(x => x.MovieId);
            return movies;
        }

        // list of clients model
        public IOrderedEnumerable<ClientsModel> ListOfClientModel()
        {
            var clients = _clientsRepository.GetAll()
                .OrderBy(x => x.ClientId);
            return clients;
        }

        // edit movie auxiliaries
        public MoviesModel EditMovieModel(int movieId)
        {
            var movie = _moviesRepository.GetById(movieId);
            return movie;
        }

        public void EditAndSaveMovie(int movieId, IFormCollection collection)
        {
            var movie = _moviesRepository.GetById(movieId);
            var title = collection["Title"].ToString();
            var year = int.Parse(collection["Year"]);
            var price = float.Parse(collection["Price"].ToString(), CultureInfo.InvariantCulture);
            var ageRestriction = int.Parse(collection["AgeRestriction"]);

            movie.Title = title;
            movie.Year = year;
            movie.Price = price;
            movie.AgeRestriction = ageRestriction;

            _moviesRepository.Update(movie);
            _moviesRepository.Save();
        }

        // delete movie auxiliaries
        public MoviesModel DeleteMovieModel(int id)
        {
            var movie = _moviesRepository.GetById(id);
            return movie;
        }

        public void DeleteAndSaveMovie(int? movieId)
        {
            var copies = _copiesRepository
                .GetMany(x => x.MovieId == movieId);
            var rentals = _rentalsRepository
                .GetMany(x => copies
                    .Select(t => t.CopyId).Contains(x.CopyId));
            _rentalsRepository.Delete(rentals);
            _rentalsRepository.Save();
            _copiesRepository.Delete(copies);
            _copiesRepository.Save();
            _moviesRepository.Delete(x => x.MovieId == movieId);
            _moviesRepository.Save();
        }

        // add movie auxiliaries
        public MoviesModel AddMovieModel(IFormCollection collection)
        {
            var id = _moviesRepository.GetAll().Max(x => x.MovieId) + 1;
            var title = collection["Title"].ToString();
            var year = int.Parse(collection["Year"]);
            var price = float.Parse(collection["Price"].ToString(), CultureInfo.InvariantCulture);
            var ageRestriction = int.Parse(collection["AgeRestriction"]);

            var movie = new MoviesModel
            {
                Title = title,
                MovieId = id,
                Year = year,
                AgeRestriction = ageRestriction,
                Price = price
            };
            return movie;
        }

        public void AddAndSaveMovie(MoviesModel movie)
        {
            _moviesRepository.Add(movie);
            _moviesRepository.Save();
        }

        // delete client auxiliaries
        public ClientsModel DeleteClientModel(int id)
        {
            var client = _clientsRepository.GetById(id);
            return client;
        }

        public void DeleteAndSaveClient(int? clientId)
        {
            _rentalsRepository.Delete(x => x.ClientId == clientId);
            _rentalsRepository.Save();
            _clientsRepository.Delete(x => x.ClientId == clientId);
            _clientsRepository.Save();
        }
    }
}
