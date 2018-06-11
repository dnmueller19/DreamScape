using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdeventure.Properties;
using ClassLibrary1;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions; //Engine

namespace TextAdeventure
{ 
	public partial class TextAdventure : Form
	{
		private Player player;

		public TextAdventure()
		{
			InitializeComponent();
			//add player things here
			player = new Player(10, 10, 20, 0, 1);

		

			// making the states go to the labels
			lblHitPoints.Text = player.CurrentHP.ToString();
			lblGold.Text = player.Gold.ToString();
			lblLevel.Text = player.Level.ToString();
			lblExperience.Text = player.ExperiencePoints.ToString();

			//Location 
			Location test1 = new Location(1, "Home", "This is your house");
			Location location = new Location(1, "Home", "This is your house", null, null, null);
			

			
		}
		
		
		private void TextAdventure_Load(object sender, EventArgs e)
		{

		}
		
		
	}
}
