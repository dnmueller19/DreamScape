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
	public class QuestCompletionItem
	{
		public Items Details { get; set; }
		public int Quanity { get; set; }


		public QuestCompletionItem(Items details, int quanity)
		{
			Details = details;
			Quanity = quanity;
		}
	}
}
