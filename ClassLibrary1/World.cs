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
		public static readonly List<Quest> Quests = new List<Quest>();
		public static readonly List<Location> Locations = new List<Location>();

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
		public const int samuraiSword = 4;
		public const int diary = 5;
		public const int reptilianSkin = 6;
		public const int repBlood = 7;
		public const int vial = 8;
		public const int headBand = 9;
		public const int pieceOfArmour = 10;
			

		//Monsters
		public const int cultMember = 1;
		public const int repTilian = 2;
		public const int samurai = 3;


		//Quests
		//clear the mansion garden of retilians
		public const int idClearTheGarden = 1;

		//defear al the samurai 
		public const int idDefeatTheSamurai = 2;

		//cultmemnet
		public const int idCollectFromCult= 3;


		

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
			Location home = new Location(idHome, "Home", "Your room is dark and for the first time you feel uneasy in your own house");
			Location townSquare = new Location(idTownSquare, "Town Square", "The square is empty...shops that are normally bustling with customers appear dark and desserted");
			Location desert = new Location(idDesert, "Desert", "");
			Location forest = new Location(idForest, "Forsest", "");
			Location city = new Location(idCity, "City", "");
			Location garden = new Location(idGarden, "Mansion Garden", "");
			Location mansion = new Location(idMansion, "Mansion", "");
			Location gaurdPost = new Location(idGaurdPost, "Gaurd Post", "");
			Location compund = new Location(idCompound, "Compund", "");


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
			Locations.Add(home);
			Locations.Add(townSquare);
			Locations.Add(forest);
			Locations.Add(city);
			Locations.Add(desert);
			Locations.Add(gaurdPost);
			Locations.Add(compund);
			Locations.Add(garden);
			Locations.Add(mansion);



		}

		private static void PopulateQuests()
		{
			Quest clearTheGarden = new Quest(idClearTheGarden,
												"Clear the Mansion's Garden",
												"Defeat all the Reptilians in the Mansion's Garden, collect 3 skins and 3 vials of blood. You will recieve a healing potion and 10 pieces of gold", 15, 10);
			clearTheGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(reptilianSkin), 3));
			clearTheGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(repBlood), 3));

			Quest defeatTheSamurai = new Quest(idDefeatTheSamurai,
				"Defeat all the Samurai!",
				"Deafeat all the Samurai in the Forest, collect 3 Headbands and 3 Pieces of Armor", 20, 15);
			defeatTheSamurai.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(headBand), 3));
			defeatTheSamurai.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(pieceOfArmour), 3));

			Quest collectFromTheCult = new Quest(idCollectFromCult,
				"Defeat the Gaurd at the GaurdPost",
				"Defeat the Cult Guard and collect a medallion", 25, 30);
			collectFromTheCult.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(medallion), 1));

				

												
												
		}

		private static void PopulateMonsters()
		{
			//reptilian
			Monster reptilian = new Monster(repTilian, "Reptilian", 3, 5, 10, 3, 3);
			reptilian.LootTable.Add(new LootItem(ItemByID(reptilianSkin), 75, false));
			reptilian.LootTable.Add(new LootItem(ItemByID(repBlood), 80, true));

			//cult member
			Monster cultyMem = new Monster(cultMember, "Cult Member", 20, 15, 40, 10, 10);
			cultyMem.LootTable.Add(new LootItem(ItemByID(medallion), 30, false));

			//Samurai
			Monster _samurai = new Monster(samurai, "Samurai", 5, 8, 12, 5, 5);
			_samurai.LootTable.Add(new LootItem(ItemByID(headBand), 70, true));
			_samurai.LootTable.Add(new LootItem(ItemByID(pieceOfArmour), 75, false));
			

			//add to MOnster List

			Monsters.Add(reptilian);
			Monsters.Add(cultyMem);
			Monsters.Add(_samurai);


		}

		

		private static void PopulateItems()
		{
			Items.Add(new Items(medallion, "Medallion", "Medallions")); //1
			Items.Add(new Weapon(knife, "Trusty Knife", "Trusty Knives", 1, 5)); //2
			Items.Add(new HealingPotion(healingPotion, "Healing Potion", "Healing Potions", 5)); //3
			Items.Add(new Weapon(samuraiSword, "Samurai Sword", "Samurai Sword", 3, 8)); //4
			Items.Add(new Items(diary, "Diary", "Diaries")); //5
			Items.Add(new Items(reptilianSkin, "Reptilian Skin", "Reptilian Skins")); //6
			Items.Add(new Items(repBlood, "Reptilian Blood", "All The Blood")); //7
			Items.Add(new Items(vial, "Vial", "Vials")); //8
			Items.Add(new Items(headBand, "Samurai Headband", "Samurai Headbands")); //9
			Items.Add(new Items(pieceOfArmour, "Piece of Samurai Armor", "Pieces of Samurai Armor")); //10

			



		}
		/// <summary>
		/// Item by ID
		/// for each loop running through the Items list 
		/// if item == id return item 
		/// else null
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static Items ItemByID(int id)
		{
			foreach (Items item in Items)
			{
				if (item.ID == id)
				{
					return item;
				}
			}
			return null;
		}

		public static Monster MonsterByID(int id)
		{
			foreach (Monster monster in Monsters)
			{

				if (monster.ID == id)
				{
					return monster;
				} 
			}
			return null;
		}

		public static Quest QuestByID(int id)
		{
			foreach(Quest quest in Quests)
			{

				if (quest.ID == id)
				{
					return quest;
				}
			}
			return null;
		}

		public static Location LocationbyID(int id)
		{
			foreach (Location location in Locations)
			{
				if (location.ID == id)
				{
					return location;
				}
			}
			return null;
		}

	}
}
