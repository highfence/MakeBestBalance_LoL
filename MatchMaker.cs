using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeBestBalance_LoL
{
	public static class MatchMaker
	{
		const int resultGameSetMaxCount = 3;

		static int matchCount = 0;

		const int maxMatchCount = 252;

		internal static List<GameSet> MakeMatch(List<Player> matchPlayers, List<Condition> conditions, ref ProgressBar progressBar, ref Label progressLabel)
		{
			/// Can't Match
			if (matchPlayers.Count != 10)
				return null;

			matchCount = 0;
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.Minimum = 0;
			progressBar.Maximum = 120;
			progressBar.Step = 1;
			progressBar.Value = 0;

			var resultGameSets = new List<GameSet>();
			resultGameSets.Clear();

			int[] team1 = new int[5];
			team1.Initialize();

			InnerMakeMatch(ref matchPlayers, ref resultGameSets, team1, 0, ref conditions, ref progressBar, ref progressLabel);

			return resultGameSets;
		}

		private static void InnerMakeMatch(ref List<Player> matchPlayers, ref List<GameSet> resultGameSets, int[] team1, int playerCount, ref List<Condition> conditions, ref ProgressBar progressBar, ref Label progressLabel)
		{
			/// if, team already made
			if (playerCount == 5)
			{
				matchCount++;
				var curGame = new GameSet(ref matchPlayers, team1);

				var isGameAccordToConditions = CheckGameSetCondition(ref curGame, ref conditions);
				if (isGameAccordToConditions)
				{
					MakeGameSetBestDiff(ref curGame);

					CompareGameSets(ref curGame, ref resultGameSets);
				}

				progressBar.PerformStep();

			}
			/// Call self recursively
			else
			{
				var remainCount = 5 - playerCount;

				int lastestAddIdx = -1;
				if (playerCount != 0)
					lastestAddIdx = team1[playerCount - 1];	

				for (int newAddIdx = lastestAddIdx + 1; newAddIdx < 10 - remainCount; ++newAddIdx)
				{
					int[] copyedTeam = team1;
					copyedTeam[playerCount] = newAddIdx;

					InnerMakeMatch(ref matchPlayers, ref resultGameSets, team1, playerCount + 1, ref conditions, ref progressBar, ref progressLabel);
				}
			}
		}

		private static bool CheckGameSetCondition(ref GameSet gameSet, ref List<Condition> conditions)
		{
			if (conditions == null || conditions.Count == 0)
				return true;

			foreach (var condition in conditions)
			{
				if (condition._state == ConditionState.PlayerInclusive)
				{
					var player1 = condition._conditionPlayers[0];
					var player2 = condition._conditionPlayers[1];

					if ((gameSet._team1.Contains(player1) && gameSet._team2.Contains(player2))
						|| (gameSet._team1.Contains(player2) && gameSet._team2.Contains(player1)))
					{
						return false;	
					}
				}
				else if (condition._state == ConditionState.PlayerExclusive)
				{
					var player1 = condition._conditionPlayers[0];
					var player2 = condition._conditionPlayers[1];

					if ((gameSet._team1.Contains(player1) && gameSet._team1.Contains(player2))
						|| (gameSet._team2.Contains(player1) && gameSet._team2.Contains(player2)))
					{
						return false;
					}
				}
			}

			return true;
		}

		private static void MakeGameSetBestDiff(ref GameSet gameSet)
		{
			double bestDiff = Double.MaxValue;
			GameSet bestGameSet = null;

			List<List<int>> team1Enum = GetPermutations(Enumerable.Range(0, 5).ToList(), 5);
			var team1Cases = team1Enum.ToList();

			foreach (var team1Case in team1Cases)
			{
				List<List<int>> team2Enum = GetPermutations(Enumerable.Range(0, 5).ToList(), 5);
				var team2Cases = team2Enum.ToList();

				foreach (var team2Case in team2Cases)
				{
					gameSet.SetCompletedTeam(team1Case, team2Case);
					var diff = gameSet.CalculateDiff();

					if (diff < bestDiff)
					{
						bestDiff = diff;
						bestGameSet = gameSet.Clone() as GameSet;
					}
				}
			}

			gameSet = bestGameSet;
		}

		private static void CompareGameSets(ref GameSet curGame, ref List<GameSet> resultGameSets)
		{
			bool isCurGameRankedIn = false;

			if (resultGameSets.Count < resultGameSetMaxCount)
				isCurGameRankedIn = true;

			foreach (var rankedGameSet in resultGameSets)
			{
				if (curGame.Diff < rankedGameSet.Diff)
				{
					isCurGameRankedIn = true;
				}
			}

			if (isCurGameRankedIn)
			{
				if (resultGameSets.Count < resultGameSetMaxCount)
				{
					resultGameSets.Add(curGame);
				}
				else
				{
					resultGameSets.RemoveAt(resultGameSets.Count - 1);
				}

				resultGameSets.Sort();
			}
		}

		private static List<List<int>> GetPermutations(List<int> candidateList, int maxLength)
		{
			var resultList = new List<List<int>>();
			var currentList = new List<int>();

			GetPermutationsInner(ref resultList, ref candidateList, currentList, 0, maxLength);

			return resultList;
		}

		private static void GetPermutationsInner(ref List<List<int>> resultList, ref List<int> candidateList, List<int> currentList, int currentIdx, int maxLength)
		{
			if (currentIdx == maxLength)
			{
				resultList.Add(currentList);
				return;
			}

			foreach (int currentInt in candidateList)
			{
				if (currentList.Contains(currentInt))
					continue;

				var copiedList = new List<int>(currentList);
				copiedList.Add(currentInt);
				GetPermutationsInner(ref resultList, ref candidateList, copiedList, currentIdx + 1, maxLength);
			}
		}
	}
}
