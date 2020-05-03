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

    public sealed class PlayerManager
    {
        public IList<Player> _players { get; private set; }     // switched field to property

        public IList<Player> Players { get; private set; }

        public PlayerManager()
        {
            _players = new List<Player>();
            Players = new ReadOnlyCollection<Player>(_players);     // composition
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
        private readonly PlayerManager pm;

        public Lobby(Tchat tchat)
        {
            _tchat = tchat;
            pm = new PlayerManager();
        }

        public void Join(Player player)
        {
            pm.AddPlayer(player);
            _tchat.Broadcast(player.Name + " has joined the lobby.");
        }
    }

    public class Game
    {
        private readonly Tchat _tchat;
        private readonly PlayerManager pm;

        public Game(Tchat tchat)
        {
            _tchat = tchat;
            pm = new PlayerManager();
        }

        public void Close()
        {
            Player[] players = pm._players.ToArray();
            foreach (var p in players)
            {
                pm.RemovePlayer(p);
            }

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
