using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeBestBalance_LoL
{
	internal sealed class PlayerManager
	{
		#region SINGLETON
		private static PlayerManager _instance;

		private PlayerManager()
		{
			_players = new List<Player>();
		}

		public static PlayerManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new PlayerManager();

				return _instance;
			}
		}
		#endregion

		public List<Player> _players;
		public List<Player> _matchPlayers;

		internal void AddPlayer(Player newPlayer)
		{
			if (newPlayer == null)
				return;

			if (_players == null)
				_players = new List<Player>();

			_players.Add(newPlayer);
			UpdatePlayerGrid();
		}

		public void UpdatePlayerGrid()
		{
			var gridManager = GridManager.Instance;
			gridManager.AddAllPlayerToGrid(_players);
		}

		internal void DeletePlayerWithName(string selectedPlayerName)
		{
			_players.RemoveAll(player => player.Name == selectedPlayerName);
		}

		public List<Player> GetPlayers()
		{
			return _players;
		}

		internal void CheckPlayerForMatching(string selectedPlayerName)
		{
			var selectedPlayer = _players.Find(player => player.Name == selectedPlayerName);

		}
	}
}
