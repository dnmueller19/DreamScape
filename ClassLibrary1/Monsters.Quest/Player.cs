using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions.Items.Weapons;

namespace ClassLibrary1.Monsters.Quest
{
	public class Player : LivingCreature
	{//Properties of the Player

		public int Gold { get; set; }
		public int Level { get; set; }
		public int ExperiencePoints { get; set; }

		public List<InventoryItem> Inventory { get; set; }
		public List<PlayerQuest> Quest { get; set; }


		public Player(int gold, int level, int experiencePoints, int currentHP, int maxHP) : base (currentHP, maxHP)
		{
			Gold = gold;
			Level = level;
			ExperiencePoints = experiencePoints;

			Inventory = new List<InventoryItem>();
			Quest = new List<PlayerQuest>();

		}

		

		//list constructors





	}
}
