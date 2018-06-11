using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ClassLibrary1.Monsters.Quest
{
	public class Player : LivingCreature
	{
		public Player(int gold, int level, int experiencePoints, int currentHP, int maxHP) : base (currentHP, maxHP)
		{
			Gold = gold;
			Level = level;
			ExperiencePoints = experiencePoints;
		}

		//Properties of the Player

		public int Gold { get; set; }
		public int Level { get; set; }
		public int ExperiencePoints { get; set; }
		
	}
}
