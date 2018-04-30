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
	public partial class ResultPage : Form
	{
		public ResultPage()
		{
			InitializeComponent();
		}

		public void StartEvaluate()
		{
			var matchPlayers = PlayerManager.Instance._matchPlayers;
			var conditions = ConditionManager.Instace._conditions;

			var matchResults = MatchMaker.MakeMatch(matchPlayers, conditions, ref progressBar1, ref ProgressLabel);

			if (matchResults != null)
			{
				int pageIdx = 1;
				foreach (var gameSet in matchResults)
				{
					DrawResults(gameSet, pageIdx);
					++pageIdx;
				}
			}

			ShowDialog();
		}

		private void DrawResults(GameSet matchResult, int page)
		{
			DataGridView currentDataGridView = null;

			if (page == 1)
			{
				currentDataGridView = this.dataGridView1;
			}
			else if (page == 2)
			{
				currentDataGridView = this.dataGridView2;
			}
			else
			{
				currentDataGridView = this.dataGridView3;
			}

			currentDataGridView.ReadOnly = true;

			currentDataGridView.ColumnCount = 6;
			currentDataGridView.Columns[0].Name = "Team1 이름";
			currentDataGridView.Columns[1].Name = "점수";
			currentDataGridView.Columns[2].Name = "MMR";
			currentDataGridView.Columns[3].Name = "Team2 이름";
			currentDataGridView.Columns[4].Name = "점수";
			currentDataGridView.Columns[5].Name = "MMR";

			// TOP
			currentDataGridView.Rows.Add("TOP", "", "", "", "", "");
			var topPlayer1 = matchResult._completeTeam1[0];
			var topPlayer2 = matchResult._completeTeam2[0];
			currentDataGridView.Rows.Add(
				topPlayer1.Name, topPlayer1.GetScore(PlayerPosition.Top), topPlayer1.Mmr,
				topPlayer2.Name, topPlayer2.GetScore(PlayerPosition.Top), topPlayer2.Mmr
				);

			// JUNGLE 
			currentDataGridView.Rows.Add("JUNGLE", "", "", "", "", "");
			var jgPlayer1 = matchResult._completeTeam1[1];
			var jgPlayer2 = matchResult._completeTeam2[1];
			currentDataGridView.Rows.Add(
				jgPlayer1.Name, jgPlayer1.GetScore(PlayerPosition.Jungle), jgPlayer1.Mmr,
				jgPlayer2.Name, jgPlayer2.GetScore(PlayerPosition.Jungle), jgPlayer2.Mmr
				);

			// MID
			currentDataGridView.Rows.Add("MID", "", "", "", "", "");
			var midPlayer1 = matchResult._completeTeam1[2];
			var midPlayer2 = matchResult._completeTeam2[2];
			currentDataGridView.Rows.Add(
				midPlayer1.Name, midPlayer1.GetScore(PlayerPosition.Mid), midPlayer1.Mmr,
				midPlayer2.Name, midPlayer2.GetScore(PlayerPosition.Mid), midPlayer2.Mmr
				);

			// AD Carry 
			currentDataGridView.Rows.Add("AD Carry", "", "", "", "", "");
			var adPlayer1 = matchResult._completeTeam1[3];
			var adPlayer2 = matchResult._completeTeam2[3];
			currentDataGridView.Rows.Add(
				adPlayer1.Name, adPlayer1.GetScore(PlayerPosition.ADCarry), adPlayer1.Mmr,
				adPlayer2.Name, adPlayer2.GetScore(PlayerPosition.ADCarry), adPlayer2.Mmr
				);

			// Support 
			currentDataGridView.Rows.Add("Support", "", "", "", "", "");
			var spPlayer1 = matchResult._completeTeam1[4];
			var spPlayer2 = matchResult._completeTeam2[4];
			currentDataGridView.Rows.Add(
				spPlayer1.Name, spPlayer1.GetScore(PlayerPosition.Support), spPlayer1.Mmr,
				spPlayer2.Name, spPlayer2.GetScore(PlayerPosition.Support), spPlayer2.Mmr
				);

			var team1Total = topPlayer1.GetScore(PlayerPosition.Top) + jgPlayer1.GetScore(PlayerPosition.Jungle) + midPlayer1.GetScore(PlayerPosition.Mid) + adPlayer1.GetScore(PlayerPosition.ADCarry) + spPlayer1.GetScore(PlayerPosition.Support);
			var team2Total = topPlayer2.GetScore(PlayerPosition.Top) + jgPlayer2.GetScore(PlayerPosition.Jungle) + midPlayer2.GetScore(PlayerPosition.Mid) + adPlayer2.GetScore(PlayerPosition.ADCarry) + spPlayer2.GetScore(PlayerPosition.Support);

			currentDataGridView.Rows.Add("Team1 Total", "", "", "Team2 Total", "", "Balance Score");
			currentDataGridView.Rows.Add(team1Total, "", "", team2Total, "", matchResult.BalanceScore);
			currentDataGridView.Rows.Add("Balance Score", "팀 점수 차이", "팀 점수 총합", "각 포지션별 차이 총합");
			currentDataGridView.Rows.Add("", "30%", "50%", "20%");
		}
	}
}
