using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeBestBalance_LoL
{
	public class GameSet
	{
		internal Player[] team1;
		internal Player[] team2;

		public double Diff { get; set; }
		
		public GameSet()
		{
			Player[] team1 = new Player[5];
			Player[] team2 = new Player[5];

			Diff = Double.MaxValue;
		}
	}
}
