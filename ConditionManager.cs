using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeBestBalance_LoL
{
	public class ConditionManager
	{
		#region SINGLETON
		private static ConditionManager _instance;

		private ConditionManager()
		{
			_conditions = new List<Condition>();
		}

		public static ConditionManager Instace
		{
			get
			{
				if (_instance == null)
					_instance = new ConditionManager();

				return _instance;
			}
		}
		#endregion

		public List<Condition> _conditions;
	}
}
