using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions.Items.Weapons;

namespace ClassLibrary1
{
	public class PlayerQuest
	{
		public Quest Details { get; set; }
		public bool QuestCompleted { get; set; }

		public PlayerQuest(Quest details)
		{
			Details = details;
			QuestCompleted = false;
		}

	}
}
