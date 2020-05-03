// TODO: Use injection instead of singleton pattern.

namespace Exercises.SingletonProblems
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using Exercises.Dependencies;

	public class Player
    {
        public string Name { get; set; }
    }

    public class PlayerManager
    {
        private static PlayerManager _instance;

        private IList<Player> _players;

        public static PlayerManager Instance
        {
            get { return _instance ?? (_instance = new PlayerManager()); }
        }
        
        public IList<Player> Players { get; private set; }

        private PlayerManager()
        {
            _players = new List<Player>();
            Players = new ReadOnlyCollection<Player>(_players);
        }

        public void AddPlayer(Player player)
        {
            if(_players.Contains(player))
                throw new ArgumentException("player");

            _players.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            if (!_players.Contains(player))
                throw new ArgumentException("player");

            _players.Remove(player);
        }
    }

    public class Lobby
    {
        private readonly Tchat _tchat;

        public Lobby(Tchat tchat)
        {
            _tchat = tchat;
        }

        public void Join(Player player)
        {
            PlayerManager.Instance.AddPlayer(player);
            _tchat.Broadcast(player.Name + " has joined the lobby.");
        }
    }

    public class Game
    {
        private readonly Tchat _tchat;

        public Game(Tchat tchat)
        {
            _tchat = tchat;
        }

        public void Close()
        {
            var players = PlayerManager.Instance.Players.ToArray();
            foreach(var p in players)
                PlayerManager.Instance.RemovePlayer(p);

            _tchat.Broadcast("Game closed.");
        }
    }

    public class E1
    {
        public static void Init(Tchat tchat)
        {
            var lobby = new Lobby(tchat);
            var game = new Game(tchat);

            var players = new[]
            {
                new Player() {Name = "John"},
                new Player() {Name = "Bob"},
                new Player() {Name = "Albert"},
            };

            foreach(var p in players)
                lobby.Join(p);

            game.Close();
        }
    }
}
