using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions.Items.Weapons;

namespace ClassLibrary1.Locations
{
	public class Location
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		//Constrictor for Location 

		public Location(int id, string name, string description, Items itemrequiredToEnter = null, Quest questAvailableHere = null, Monster monsterLivingHere = null)
		{
			ID = id;
			Name = name;
			Description = description;
		}

		public Items ItemRequiredToEnter { get; set; }
		public Quest QuestAvailableHere { get; set; }
		public Monster MonsterLivingHere { get; set; }
		public Location LocationNorth { get; set; }
		public Location LocationSouth { get; set; }
		public Location LocationEast { get; set; }
		public Location LocationWest { get; set; }

		

	}
}
