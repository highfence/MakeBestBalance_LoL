using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeBestBalance_LoL
{
	public enum ConditionState
	{
		None,
		PlayerInclusive,
		PlayerExclusive
	}

	public class Condition
	{
		public ConditionState _state = ConditionState.None;

		internal List<Player> _conditionPlayers;

		public Condition()
		{
			_conditionPlayers = new List<Player>();
		}
	}
}
