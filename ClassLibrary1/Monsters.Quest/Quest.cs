using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Potions.Items.Weapons;
using ClassLibrary1;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;


namespace ClassLibrary1.Monsters.Quest
{
	public class Quest
	{//Properties of the Player

		public int Gold { get; set; }
		public int Level { get; set; }
		public int ExperiencePoints { get; set; }

		public List<InventoryItem> Inventory { get; set; }
		public List<PlayerQuest> PlayerQuest { get; set; }

		//properties (iID,sName, sPluralName, irewardexp, rewardgold)

		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int RewardEXP { get; set; }
		public int RewardGold { get; set; }
		public Items RewardItem { get; set; }
		public List<QuestCompletionItem> QuestCompletionItems { get; set; }

		//Constructor 

		public Quest(int id, string name, string description, int rewardEXP, int rewardGold)
		{
			ID = id;
			Name = name;
			Description = description;
			RewardEXP = rewardEXP;
			RewardGold = rewardGold;
			QuestCompletionItems = new List<QuestCompletionItem>();
		}
	}
}
