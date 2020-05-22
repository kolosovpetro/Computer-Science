using System;
using System.Collections.Generic;
using System.Linq;
using IdentityAndPostgres.Infrastructure;
using IdentityAndPostgres.Models;
using IdentityAndPostgres.Repositories;
using IdentityAndPostgres.ViewModels;
using Microsoft.AspNetCore.Http;

namespace IdentityAndPostgres.Services
{
    public class ClientServices
    {
        private readonly CopiesRepository _copiesRepository;
        private readonly ClientsRepository _clientsRepository;
        private readonly RentalsRepository _rentalsRepository;
        private readonly MoviesRepository _moviesRepository;

        public ClientServices()
        {
            _copiesRepository = new CopiesRepository(new DbFactory());
            _clientsRepository = new ClientsRepository(new DbFactory());
            _rentalsRepository = new RentalsRepository(new DbFactory());
            _moviesRepository = new MoviesRepository(new DbFactory());
        }

        // client history view model
        public IEnumerable<ClientHistoryViewModel> GetHistory(int clientId)
        {
            return (from r in _rentalsRepository.GetAll()
                    join c in _clientsRepository.GetAll()
                        on r.ClientId equals c.ClientId
                    join cop in _copiesRepository.GetAll()
                        on r.CopyId equals cop.CopyId
                    join mov in _moviesRepository.GetAll()
                        on cop.MovieId equals mov.MovieId
                    select new ClientHistoryViewModel
                    {
                        Title = mov.Title,
                        Year = mov.Year,
                        AgeRestriction = mov.AgeRestriction,
                        MovieId = mov.MovieId,
                        Price = mov.Price,
                        Client = c
                    })
                .Where(x => x.Client.ClientId == clientId)
                .OrderBy(x => x.MovieId)
                .Distinct();
        }

        // client sign in get view model
        public ClientsModel ClientSignInModel(IFormCollection collection)
        {
            var username = collection["FirstName"].ToString();
            var password = collection["LastName"].ToString();

            var client = _clientsRepository.GetAll()
                .FirstOrDefault(x => x.FirstName == username && x.LastName == password);
            return client;
        }

        // client dashboard view model
        public ClientsModel UserDashboardModel(int id)
        {
            var client = _clientsRepository.GetAll()
                .FirstOrDefault(x => x.ClientId == id);
            return client;
        }

        // rent view model
        public IOrderedEnumerable<MoviesViewModel> RentMovieViewModel()
        {
            var viewModel =
                (from mov in _moviesRepository.GetAll()
                 join cop in _copiesRepository.GetAll()
                     on mov.MovieId equals cop.MovieId
                 select new MoviesViewModel
                 {
                     Title = mov.Title,
                     MovieId = mov.MovieId,
                     Year = mov.Year,
                     AgeRestriction = mov.AgeRestriction,
                     Price = mov.Price,
                     Available = cop.Available
                 })
                .Where(x => x.Available != null && (bool)x.Available)
                .OrderBy(g => g.MovieId);
            return viewModel;
        }

        // client register view model and auxiliary
        public void AddToDatabase(ClientsModel client)
        {
            _clientsRepository.Add(client);
            _clientsRepository.Save();
        }

        public ClientsModel ClientRegisterPost(IFormCollection collection)
        {
            var clientId = _clientsRepository.GetAll().Max(x => x.ClientId) + 1;
            var firstname = collection["FirstName"];
            var lastname = collection["LastName"];
            var birthday = Convert.ToDateTime(collection["Birthday"]);

            var client = new ClientsModel
            {
                ClientId = clientId,
                FirstName = firstname,
                LastName = lastname,
                Birthday = birthday
            };
            return client;
        }

        // get success view model
        public ClientsModel GetSuccessModel(int id)
        {
            return _clientsRepository.GetById(id);
        }
    }
}
