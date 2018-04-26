using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeBestBalance_LoL
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			var gridManager = GridManager.Instance;
			gridManager.Initialize(PlayerGridView);
		}

		private void InsertNewPlayer(object sender, EventArgs e)
		{
			using (var insertForm = new NewPlayerBox())
			{
				if (insertForm.ShowDialog() == DialogResult.OK)
				{
					
				}
			}
		}
	}
}
