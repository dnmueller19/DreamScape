﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions.Items.Weapons;

namespace ClassLibrary1
{
	public class LootItem
	{
		public Items Details { get; set; }
		public int DropPercentage { get; set;}
		public bool DefaultItem { get; set; }



		public LootItem(Items details, int dropPercentage, bool defaultItem)
		{
			Details = details;
			DropPercentage = dropPercentage;
			DefaultItem = defaultItem;
		}
	}
}
