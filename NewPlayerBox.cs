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
	public partial class NewPlayerBox : Form
	{
		public NewPlayerBox()
		{
			InitializeComponent();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			var newPlayer = new Player();

			try
			{
				newPlayer.SetScore(PlayerPosition.Top, Convert.ToSingle(TopText.Text));
				newPlayer.SetScore(PlayerPosition.Jungle, Convert.ToSingle(JungleText.Text));
				newPlayer.SetScore(PlayerPosition.Mid, Convert.ToSingle(MidText.Text));
				newPlayer.SetScore(PlayerPosition.ADCarry, Convert.ToSingle(AdText.Text));
				newPlayer.SetScore(PlayerPosition.Support, Convert.ToSingle(SupportText.Text));

				newPlayer.Name = NameText.Text;
				newPlayer.GameId = GameIdText.Text; 
			}
			catch (Exception exception)
			{
				MessageBox.Show($"제대로 된 값을 넣어주세요! ErrorMsg : {exception.Message}");
			}

			var playerManager = PlayerManager.Instance;
			playerManager.AddPlayer(newPlayer);

			this.Close();
		}
	}
}
