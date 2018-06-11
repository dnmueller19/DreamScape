using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Potions.Items.Weapons
{
	public class HealingPotion : Items
	{
		public HealingPotion(int id, string name, string pluralName, int amountToHeal) : base (id, name, pluralName)
		{
			AmountToHeal = amountToHeal;
		}

		//protperties 

		public int AmountToHeal { get; set; }
	}
}
