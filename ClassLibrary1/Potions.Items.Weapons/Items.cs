using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Potions.Items.Weapons
{
	public class Items
	{
		//properties

		public int ID { get; set; }
		public string Name { get; set; }
		public string PluralName { get; set; }

		//constructor

		public Items(int id, string name, string pluralName)
		{
			ID = id;
			Name = name;
			PluralName = pluralName;

		}
	}
}
