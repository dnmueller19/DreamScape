using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions.Items.Weapons;
using ClassLibrary1;

namespace ClassLibrary1
{
	public static class World
	{
		//Lists for different things in the game 

		public static readonly List<Monster> Monsters = new List<Monster>();
		public static readonly List<Items> Items = new List<Items>();
		public static readonly List<Quest> Quest = new List<Quest>();
		public static readonly List<Location> Location = new List<Location>();

		//create varibles for locations, items, monstes,, and quests

		//Locations
		public const int idHome = 1;
		public const int idTownSquare = 2;
		public const int idDesert = 3;
		public const int idForest = 4;
		public const int idCity = 5;
		public const int idGarden = 6;
		public const int idMansion = 7;
		public const int idGaurdPost = 8;
		public const int idCompound = 9;

		//Items
		public const int medallion = 1;
		public const int knife = 2;
		public const int healingPotion = 3;
		public const int //weapon = 4;
		public const int diary = 5;
		public const int reptilianSkin = 6;
		public const int repBlood = 7;
		public const int vial = 8;
		//9
		//10

		//Monsters
		public const int cultMember = 1;
		public const int repTilian = 2;
		//3


		//Quests
		//1
		//2


		

		static World()
		{
			PopulateItems();
			PopulateMonsters();
			PopulateQuests();
			PopulateLocations();
		}

		//add those varibles to each of the list for items location and mosnter
		//create/populate new quests for the quests/locagtions/monsters
		private static void PopulateLocations()
		{
			Location home = new Location(idHome, "Home", "Your room is dark and for the first time you feel uneasy in your own house"));
			Location townSquare = new Location(idTownSquare, "Town Square", "The square is empty...shops that are normally bustling with customers appear dark and desserted");
			Location desert = new Location(idDesert, "", "");
			Location forest = new Location(idForest, "", "");
			Location city = new Location(idCity, "", "");
			Location garden = new Location(idGarden, "", "");
			Location mansion = new Location(idMansion, "", "");
			Location gaurdPost = new Location(idGaurdPost, "", "");
			Location compund = new Location(idCompound, "", "");


			//link locations 
			//from you house
			home.LocationSouth = townSquare;

			//from town square
			townSquare.LocationNorth = home;
			townSquare.LocationSouth = forest;
			townSquare.LocationEast = desert;
			townSquare.LocationWest = garden;

			//from garden
			garden.LocationWest = mansion;
			garden.LocationEast = townSquare;

			//from mansion
			mansion.LocationEast = garden;

			//from forest
			forest.LocationSouth = city;
			forest.LocationNorth = townSquare;

			// from desert
			desert.LocationWest = townSquare;
			desert.LocationEast = gaurdPost;

			//from gaurdpost
			gaurdPost.LocationWest = desert;
			gaurdPost.LocationEast = compund;

			//from compund
			compund.LocationWest = gaurdPost;

			//add loctions to static locations list
			Location.Add(home);
			Location.Add(townSquare);
			Location.Add(forest);
			Location.Add(city);
			Location.Add(desert);
			Location.Add(gaurdPost);
			Location.Add(compund);
			Location.Add(garden);
			Location.Add(mansion);



		}

		private static void PopulateQuests()
		{
			throw new NotImplementedException();
		}

		private static void PopulateMonsters()
		{
			//reptilian
			Monster reptilian = new Monster(repTilian, "Reptilian", 3, 5, 10, 3, 3);
			reptilian.LootTable.Add(new LootItem(ItemByID(reptilianSkin), 75, false));
			reptilian.LootTable.Add(new LootItem(ItemByID(repBlood), 80, true));

			//cult member
			Monster cultyMem = new Monster(cultMember, "Cult Member", 20, 15, 40, 10, 10);
			cultyMem.LootTable.Add(new LootItem(ItemByID(cultMember), 75, false));

			//3rd monster


			//add to MOnster List

			Monsters.Add(reptilian);
			Monsters.Add(cultyMem);


		}

		

		private static void PopulateItems()
		{
			Items.Add(new Items(medallion, "Medallion", "Medallions")); //1
			Items.Add(new Weapon(knife, "Rusty Knife", "Rusty Knives", 1, 5)); //2
			Items.Add(new HealingPotion(healingPotion, "Healing Potion", "Healing Potions", 5)); //3
			//Items.Add(new Weapon()) //4
			Items.Add(new Items(diary, "Diary", "Diaries")); //5
			Items.Add(new Items(reptilianSkin, "Reptilian Skin", "Reptilian Skins")); //6
			Items.Add(new Items(repBlood, "Reptilian Blood", "All The Blood")); //7
			Items.Add(new Items(vial, "Vial", "Vials")); //8
														 //9
														 //10

			



		}
		/// <summary>
		/// Item by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static Items ItemByID(int id)
		{
			throw new NotImplementedException();
		}

	}
}
