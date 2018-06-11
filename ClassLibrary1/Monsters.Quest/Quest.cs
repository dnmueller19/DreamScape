using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Potions.Items.Weapons;

namespace ClassLibrary1.Monsters.Quest
{
	public class Quest
	{
		//properties (iID,sName, sPluralName, irewardexp, rewardgold)

		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int RewardEXP{ get; set; }
		public int RewardGold{ get; set; }
		public Items RewardItem { get; set; }

		//Constructor 

		public Quest(int id, string name, string description, int rewardEXP, int rewardGold)
		{
			ID = id;
			Name = name;
			Description = description;
			RewardEXP = rewardEXP;
			RewardGold = rewardGold;
		}
	}
}
