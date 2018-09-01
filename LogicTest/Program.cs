using System;
using LogicLib;
using DomainClassLib;
using System.Collections.Generic;
using System.Linq;

namespace LogicTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Player player = new Player()
			{
				Name = "TestPlayer",
				GameId = "TestId"
			};

			var scores = new float[Enum.GetValues(typeof(PlayerPosition)).Length];

			Random rng = new Random();
			foreach (PlayerPosition position in Enum.GetValues(typeof(PlayerPosition)))
			{
				float randNumber = (rng.Next(0, 1000)) / 100;
				scores[(int)position] = randNumber;
			}

			player.Scores = scores;
			LogicLib.MatchMaker.TestInterop(player);
		}
	}
}
