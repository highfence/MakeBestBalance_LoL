using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeBestBalance_LoL
{
	internal enum PlayerPosition
	{
		Top     = 0,
		Jungle  = 1,
		Mid     = 2,
		ADCarry = 3,
		Support = 4,
	}

	[Serializable]
	internal sealed class Player
	{
		public const int positionNumber = 5;

		private float[] _scores;

		public string Name { get; set; }

		public string GameId { get; set; }

		public int Mmr { get; set; }

		internal Player()
		{
			_scores = new float[positionNumber];
			Array.Clear(_scores, 0, positionNumber);
		}

		public void SetScore(PlayerPosition position, float score)
		{
			int scoreIdx = Convert.ToInt32(position);
			_scores[scoreIdx] = score;
		}

		public float GetScore(PlayerPosition position)
		{
			int scoreIdx = Convert.ToInt32(position);
			return _scores[scoreIdx];
		}
	}
}
