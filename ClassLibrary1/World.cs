using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions.Items.Weapons;
using ClassLibrary1;

namespace ClassLibrary1
{
	public static class World
	{
		//Lists for different things in the game 

		public static readonly List<Monster> Monsters = new List<Monster>();
		public static readonly List<Items> Items = new List<Items>();
		public static readonly List<Quest> Quest = new List<Quest>();
		public static readonly List<Location> Location = new List<Location>();

		//create varibles for locations, items, monstes,, and quests

		//add those varibles to each of the list for items location and mosnter
		//create/populate new quests for the quests/locagtions/monsters

	}
}
