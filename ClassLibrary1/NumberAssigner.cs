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
	public static class NumberAssigner
	{
		static int number = 0;
		public static int NumberCounter()
		{
			number = (number + 1);

			return number;
		}

	}
}
