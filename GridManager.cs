using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeBestBalance_LoL
{
	internal sealed class GridManager 
	{
		#region SINGLETON
		private static GridManager _instance;

		private GridManager()
		{

		}

		public static GridManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new GridManager();

				return _instance;
			}
		}
		#endregion

		public DataGridView _gridView { get; set; }

		public void Initialize(DataGridView dataGridView)
		{
			_gridView = dataGridView;

			_gridView.ColumnCount = 8;
			_gridView.Columns[0].Name = "이름";
			_gridView.Columns[1].Name = "TOP";
			_gridView.Columns[2].Name = "MID";
			_gridView.Columns[3].Name = "JUNGLE";
			_gridView.Columns[4].Name = "AD CARRY";
			_gridView.Columns[5].Name = "SUPPORT";
			_gridView.Columns[6].Name = "AVERAGE";
			_gridView.Columns[7].Name = "MMR";
		}

		public void AddAllPlayerToGrid(List<Player> playerList)
		{
			if (_gridView == null || playerList == null)
				return;

			_gridView.Rows.Clear();

			foreach(var playerInfo in playerList)
			{
				string name        = playerInfo.Name;
				float topValue     = Convert.ToSingle(Math.Round(playerInfo.GetScore(PlayerPosition.Top), 1));
				float jungleValue  = Convert.ToSingle(Math.Round(playerInfo.GetScore(PlayerPosition.Jungle), 1));
				float midValue     = Convert.ToSingle(Math.Round(playerInfo.GetScore(PlayerPosition.Mid), 1));
				float adValue      = Convert.ToSingle(Math.Round(playerInfo.GetScore(PlayerPosition.ADCarry), 1));
				float supportValue = Convert.ToSingle(Math.Round(playerInfo.GetScore(PlayerPosition.Support), 1));
				double average     = Math.Round((topValue + jungleValue + midValue + adValue + supportValue) / 5, 2);

				_gridView.Rows.Add(name, topValue, jungleValue, midValue, adValue, supportValue, average, 0);
			}
		}

		internal void SelectPlayer(int rowIndex)
		{
			string playerName;

			playerName = _gridView.Rows[rowIndex].Cells[0].Value.ToString();

			PlayerManager.Instance.CheckPlayerToMatching(playerName);
		}

		public string GetSelectedPlayerName()
		{
			string playerName;

			int selectedRowIdx = _gridView.CurrentCell.RowIndex;

			playerName = _gridView.Rows[selectedRowIdx].Cells[0].Value.ToString();

			return playerName;
		}
	}
}
