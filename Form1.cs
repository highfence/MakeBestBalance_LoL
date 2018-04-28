using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeBestBalance_LoL
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			PlayerManager.Instance.Initialize(MatchPlayerCount);
			GridManager.Instance.Initialize(PlayerGridView);
			TabManager.Instance.Initialize(Tabs);
		}

		private void InsertNewPlayer(object sender, EventArgs e)
		{
			TabManager.Instance.SetTabFocus(TabName.playerList);

			var insertForm = new NewPlayerBox();
			insertForm.ShowDialog();
		}

		private void DeleteSelectPlayer(object sender, EventArgs e)
		{
			TabManager.Instance.SetTabFocus(TabName.playerList);

			var selectedPlayerName = GridManager.Instance.GetSelectedPlayerName();
			if (String.IsNullOrEmpty(selectedPlayerName) == false)
			{
				PlayerManager.Instance.DeletePlayerWithName(selectedPlayerName);
				PlayerManager.Instance.UpdatePlayerGrid();
			}
		}

		private void SavePlayerListToFile(object sender, EventArgs e)
		{
			TabManager.Instance.SetTabFocus(TabName.playerList);

			var fileManager = FileManager.Instace;
			var savePath = fileManager.OpenSaveFileDirectoryWindow("저장할 폴더를 선택해주세요.", "mbb", "MakeBestBalance File(*.mbb) | *.mbb");

			fileManager.SavePlayers(savePath, PlayerManager.Instance.GetPlayers());
		}

		private void LoadPlayersFromFile(object sender, EventArgs e)
		{
			TabManager.Instance.SetTabFocus(TabName.playerList);

			var fileManager = FileManager.Instace;
			var loadPath = fileManager.OpenFileDirectoryWindow("로드할 파일을 선택해주세요.", "mbb", "MakeBestBalance File(*.mbb) | *.mbb");

			var players = fileManager.LoadPlayers(loadPath);
			foreach (var player in players)
			{
				PlayerManager.Instance.AddPlayer(player);
			}

			PlayerManager.Instance.UpdatePlayerGrid();
		}

		private void PlayerGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			GridManager.Instance.SelectPlayer(e.RowIndex);
		}

		private void SelectAllPlayerCheckBox_CheckStateChanged(object sender, EventArgs e)
		{
			var isChecked = SelectAllPlayerCheckBox.Checked;
			PlayerManager.Instance.CheckMatchAll(isChecked);
			GridManager.Instance.CheckMatchAll(isChecked);
		}
	}
}
