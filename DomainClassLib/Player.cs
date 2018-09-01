using System;
using System.Collections.Generic;

namespace DomainClassLib
{
	public enum PlayerPosition
	{
		Top = 0,
		Jungle = 1,
		Mid = 2,
		ADCarry = 3,
		Support = 4,
	}

	public sealed class Player
    {
		public ICollection<float> Scores;

		public string Name { get; set; }

		public string GameId { get; set; }
	}
}
