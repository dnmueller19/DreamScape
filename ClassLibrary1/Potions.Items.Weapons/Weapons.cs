using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Potions.Items.Weapons
{
	public class Weapon : Items
	{
	
		public int MaxDamage { get; set; }
		public int MinDamage { get; set; }

		//constructor

		public Weapon(int id, string name, string pluralName, int minDamage, int maxDamage) : base(id, name, pluralName)
		{
			MinDamage = minDamage;
			MaxDamage = maxDamage;
		}
	}
}
