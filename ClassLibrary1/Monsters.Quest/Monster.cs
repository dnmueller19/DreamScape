using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions;

namespace ClassLibrary1.Monsters.Quest
{
	public class Monster : LivingCreature
	{
		public Monster(int iD, string name, int maxDamage, int rewardEXP, int rewardGold, int currentHP, int maxHP) : base(currentHP, maxHP)
		{
			ID = iD;
			Name = name;
			MaxDamage = maxDamage;
			RewardEXP = rewardEXP;
			RewardGold = rewardGold;

			LootTable = new List<LootItem>();
		}

		//properies (id,sname,imaxHP,icurrentHP, imaxdamage, iEXreward, igoldReward)

		public int ID { get; set; }
		public string Name { get; set; }
		public int MaxDamage { get; set; }
		public int RewardEXP { get; set; }
		public int RewardGold { get; set; }
		public List<LootItem> LootTable { get; set; }
		//constructor 

		
	}
}
