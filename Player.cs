using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeBestBalance_LoL
{
	public enum PlayerPosition
	{
		Top     = 0,
		Jungle  = 1,
		Mid     = 2,
		ADCarry = 3,
		Support = 4,
	}

	[Serializable]
	public sealed class Player : ICloneable
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

		public object Clone()
		{
			var copiedPlayer = new Player();

			for (int scoreIdx = 0; scoreIdx < _scores.Length; ++scoreIdx)
			{
				copiedPlayer._scores[scoreIdx] = _scores[scoreIdx];
			}

			copiedPlayer.Name = Name;
			copiedPlayer.GameId = GameId;
			// MMR은 추후 구현 예정. (선수 목록에서 관리하지 않는 것이 더 나을 것 같다.)

			return copiedPlayer;
		}
	}
}
