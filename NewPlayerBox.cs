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
				float topScore     = Convert.ToSingle(TopText.Text);
				float jungleScore  = Convert.ToSingle(JungleText.Text);
				float midScore     = Convert.ToSingle(MidText.Text);
				float adScore      = Convert.ToSingle(AdText.Text);
				float supportScore = Convert.ToSingle(SupportText.Text);

				if (0.0f > topScore || topScore > 10.0f
					|| 0.0f > jungleScore || jungleScore > 10.0f
					|| 0.0f > midScore || midScore > 10.0f
					|| 0.0f > adScore || adScore > 10.0f
					|| 0.0f > supportScore || supportScore > 10.0f)
				{
					throw new System.InvalidOperationException("점수는 0에서 10점까지의 점수를 입력해주세요.");
				}

				newPlayer.SetScore(PlayerPosition.Top,     Convert.ToSingle(TopText.Text));
				newPlayer.SetScore(PlayerPosition.Jungle,  Convert.ToSingle(JungleText.Text));
				newPlayer.SetScore(PlayerPosition.Mid,     Convert.ToSingle(MidText.Text));
				newPlayer.SetScore(PlayerPosition.ADCarry, Convert.ToSingle(AdText.Text));
				newPlayer.SetScore(PlayerPosition.Support, Convert.ToSingle(SupportText.Text));

				newPlayer.Name = NameText.Text;
				newPlayer.GameId = GameIdText.Text;

				var playerManager = PlayerManager.Instance;
				playerManager.AddPlayer(newPlayer);
			}
			catch (Exception exception)
			{
				MessageBox.Show($"에러입니다 :D \nErrorMsg : {exception.Message}");
			}

			this.Close();
		}
	}
}
