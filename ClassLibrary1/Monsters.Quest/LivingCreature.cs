using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Monsters.Quest
{
	public class LivingCreature
	{
		public int CurrentHP { get; set; }
		public int MaxHP { get; set; }

		//constructor
		public LivingCreature(int currentHP, int maxHP)
		{
			CurrentHP = currentHP;
			MaxHP = maxHP;
		}

		
	}

	
}
