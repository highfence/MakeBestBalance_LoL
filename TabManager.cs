using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeBestBalance_LoL
{
	public enum TabName
	{
		playerList = 0,
		matchPlayerList = 1,
	}

	public class TabManager
	{
		#region SINGLETON
		private static TabManager _instance;

		private TabManager()
		{

		}

		public static TabManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new TabManager();

				return _instance;
			}
		}
		#endregion

		private TabControl _tabControl = null;

		public void Initialize(TabControl tabControl)
		{
			_tabControl = tabControl;
		}

		public void SetTabFocus(TabName tabName)
		{
			int tabIdx = Convert.ToInt32(tabName);
			_tabControl.SelectedIndex = tabIdx;
		}
	}
}
