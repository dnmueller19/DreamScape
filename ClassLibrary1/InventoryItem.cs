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
	public class InventoryItem
	{
		public Items Details { get; set; }
		public int Quantity { get; set; }

		public InventoryItem(Items details, int quantity)
		{
			Details = details;
			Quantity = quantity;
		}
	}
}
