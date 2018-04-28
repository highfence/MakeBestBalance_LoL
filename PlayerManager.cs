using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeBestBalance_LoL
{
	internal sealed class PlayerManager
	{
		#region SINGLETON
		private static PlayerManager _instance;

		private PlayerManager()
		{
			_players = new List<Player>();
			_matchPlayers = new List<Player>();
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
		Label _matchPlayerLabel;

		public void Initialize(Label label)
		{
			_matchPlayerLabel = label;

			UpdateMatchPlayerCount();
		}

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

		internal bool CheckPlayerForMatching(string selectedPlayerName)
		{
			// 이미 매칭 플레이어 목록에 있는 경우, 셀렉트 해제 되었다고 판단.
			if (_matchPlayers.Find(player => player.Name == selectedPlayerName) != null)
			{
				_matchPlayers.RemoveAll(player => player.Name == selectedPlayerName);
				return false;
			}

			var selectedPlayer = _players.Find(player => player.Name == selectedPlayerName);

			var copiedPlayer = selectedPlayer.Clone() as Player;

			_matchPlayers.Add(copiedPlayer);

			return true;
		}

		internal void UpdateMatchPlayerCount()
		{
			if (_matchPlayerLabel == null)
				return;

			string matchPlayerText = $"선택된 선수 수 : {_matchPlayers.Count}";

			_matchPlayerLabel.Text = matchPlayerText;
		}

		internal void CheckMatchAll(bool isChecked)
		{
			_matchPlayers.Clear();
			if (isChecked)
			{
				foreach (var player in _players)
				{
					var copiedPlayer = player.Clone() as Player;
					_matchPlayers.Add(copiedPlayer);	
				}
			}

			UpdateMatchPlayerCount();
		}
	}
}
