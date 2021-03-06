﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeBestBalance_LoL
{
	public sealed class GameSet : IComparable, ICloneable
	{
		public List<Player> _team1;
		public List<Player> _team2;

		public Player[] _completeTeam1;
		public Player[] _completeTeam2;

		public double Diff { get; set; }
		public float TeamTotal { get; set; }
		public float PositionDiffTotal { get; set; }
		public double BalanceScore { get; set; }

		public GameSet()
		{
			_team1 = new List<Player>();
			_team2 = new List<Player>();

			_completeTeam1 = new Player[5];
			_completeTeam2 = new Player[5];

			Diff = Double.MaxValue;
		}

		public GameSet(ref List<Player> playerList, int[] team1)
		{
			_team1 = new List<Player>();
			_team2 = new List<Player>();

			_completeTeam1 = new Player[5];
			_completeTeam2 = new Player[5];

			Diff = Double.MaxValue;

			for (int i = 0; i < 10; ++i)
			{
				if (team1.Contains(i))
				{
					_team1.Add(playerList[i].Clone() as Player);
				}
				else
				{
					_team2.Add(playerList[i].Clone() as Player);
				}
			}
		}

		public int CompareTo(object obj)
		{
			var otherGameSet = obj as GameSet;
			if (otherGameSet == null)
			{
				throw new ApplicationException("GameSet 비교 객체가 null입니다.");
			}

			if (BalanceScore < otherGameSet.BalanceScore)
				return 1;
			else if (BalanceScore == otherGameSet.BalanceScore)
				return 0;
			else
				return -1;
		}

		public double CalculateDiff()
		{
			float team1Total = 0.0f;
			float team2Total = 0.0f;
			PositionDiffTotal = 0.0f;

			for (int i = 0; i < 4; ++i)
			{
				if (i != 4)
				{
					team1Total += _completeTeam1[i].GetScore((PlayerPosition)i);
					team2Total += _completeTeam2[i].GetScore((PlayerPosition)i);
				}
				else
				{
					team1Total += _completeTeam1[3].GetScore(PlayerPosition.ADCarry) * 0.25f + _completeTeam1[4].GetScore(PlayerPosition.Support) * 0.75f;
					team2Total += _completeTeam2[3].GetScore(PlayerPosition.ADCarry) * 0.25f + _completeTeam2[4].GetScore(PlayerPosition.Support) * 0.75f;
				}

				if (i != 4)
				{
					PositionDiffTotal += Math.Abs(_completeTeam1[i].GetScore((PlayerPosition)i) - _completeTeam2[i].GetScore((PlayerPosition)i));
				}
				else
				{
					PositionDiffTotal += Math.Abs(_completeTeam1[3].GetScore(PlayerPosition.ADCarry) * 0.25f + _completeTeam1[4].GetScore(PlayerPosition.Support) * 0.75f - _completeTeam2[3].GetScore(PlayerPosition.ADCarry) * 0.25f - _completeTeam2[4].GetScore(PlayerPosition.Support) * 0.75f);
				}
			}

			TeamTotal = team1Total + team2Total;
			Diff = Math.Abs(team1Total - team2Total);

			return Diff;
		}

		public object Clone()
		{
			GameSet copiedGameSet = new GameSet();

			foreach(var team1Player in this._team1)
			{
				copiedGameSet._team1.Add(team1Player.Clone() as Player);
			}
			foreach(var team2Player in this._team2)
			{
				copiedGameSet._team2.Add(team2Player.Clone() as Player);
			}

			this._completeTeam1.CopyTo(copiedGameSet._completeTeam1, 0);
			this._completeTeam2.CopyTo(copiedGameSet._completeTeam2, 0);

			copiedGameSet.Diff = this.Diff;
			copiedGameSet.TeamTotal = this.TeamTotal;
			copiedGameSet.PositionDiffTotal = this.PositionDiffTotal;
			copiedGameSet.BalanceScore = this.BalanceScore;

			return copiedGameSet;
		}

		public void SetCompletedTeam(List<int> team1, List<int> team2)
		{
			var team1List = team1.ToList();
			var team2List = team2.ToList();

			for (int i = 0; i < 5; ++i)
			{
				_completeTeam1[team1List[i]] = _team1[i];
				_completeTeam2[team2List[i]] = _team2[i];
			}
		}
	}
}
