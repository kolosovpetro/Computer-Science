using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using IdentityAndPostgres.Infrastructure;
using IdentityAndPostgres.Models;
using IdentityAndPostgres.Repositories;
using Microsoft.AspNetCore.Http;

namespace IdentityAndPostgres.Services
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
            IDbFactory dbFactory = new DbFactory();
            _copiesRepository = new CopiesRepository(dbFactory);
            _clientsRepository = new ClientsRepository(dbFactory);
            _rentalsRepository = new RentalsRepository(dbFactory);
            _moviesRepository = new MoviesRepository(dbFactory);
            _employeesRepository = new EmployeesRepository(dbFactory);
        }

        // admin sign in view model
        public EmployeesModel AdminSignInModel(IFormCollection collection)
        {
            var username = collection["FirstName"].ToString();
            var password = collection["LastName"].ToString();
            return _employeesRepository.Get(x => x.FirstName == username && x.LastName == password);
        }

        // admin dashboard view model
        public EmployeesModel GetEmployeeModelById(int adminId)
        {
            return _employeesRepository.GetById(adminId);
        }

        // add client auxiliary methods
        public ClientsModel AddClientModel(IFormCollection collection)
        {
            var id = _clientsRepository.GetAll().Max(x => x.ClientId) + 1;
            var firstname = collection["FirstName"].ToString();
            var lastname = collection["LastName"].ToString();
            var birthday = Convert.ToDateTime(collection["Birthday"]);

            return new ClientsModel
            {
                ClientId = id,
                FirstName = firstname,
                LastName = lastname,
                Birthday = birthday
            };
        }

        public void AddAndSaveClientInDatabase(ClientsModel client)
        {
            _clientsRepository.Add(client);
            _clientsRepository.Save();
        }

        // edit client
        public ClientsModel GetClientModelById(int id)
        {
            return _clientsRepository.GetById(id);
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
        public IEnumerable<MoviesModel> ListOfMoviesModel()
        {
            return _moviesRepository.GetAll().OrderBy(x => x.MovieId);
        }

        // list of clients model
        public IEnumerable<ClientsModel> ListOfClientModel()
        {
            return _clientsRepository.GetAll().OrderBy(x => x.ClientId);
        }

        // edit movie auxiliaries

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
        public MoviesModel GetMovieById(int movieId)
        {
            return _moviesRepository.GetById(movieId);
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

            return new MoviesModel
            {
                Title = title,
                MovieId = id,
                Year = year,
                AgeRestriction = ageRestriction,
                Price = price
            };
        }

        public void AddAndSaveMovie(MoviesModel movie)
        {
            _moviesRepository.Add(movie);
            _moviesRepository.Save();
        }

        // delete client auxiliaries

        public void DeleteAndSaveClient(int? clientId)
        {
            _rentalsRepository.Delete(x => x.ClientId == clientId);
            _rentalsRepository.Save();
            _clientsRepository.Delete(x => x.ClientId == clientId);
            _clientsRepository.Save();
        }
    }
}
