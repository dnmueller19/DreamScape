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
	public static class RandomNumber
	{
		private static Random generator = new Random();

		public static int NumbeBetween(int minValue, int maxValue)
		{
			return generator.Next(minValue, maxValue + 1);
		}
	}
}
