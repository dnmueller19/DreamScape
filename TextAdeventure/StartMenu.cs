using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAdeventure
{
	public partial class StartMenu : Form
	{
		public StartMenu()
		{
			InitializeComponent();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			TextAdventure window = new TextAdventure();
			window.ShowDialog();
			this.Close();
			
		}
	}
}
