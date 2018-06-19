using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions.Items.Weapons;

namespace ClassLibrary1.Monsters.Quest
{
	public class Player : LivingCreature
	{//Properties of the Player

		public int Gold { get; set; }
		public int Level { get; set; }
		public int ExperiencePoints { get; set; }
		public Location CurrentLocation { get; set; }

		public List<InventoryItem> Inventory { get; set; }
		public List<PlayerQuest> Quest { get; set; }


		public Player(int gold, int level, int experiencePoints, int currentHP, int maxHP) : base (currentHP, maxHP)
		{
			Gold = gold;
			Level = level;
			ExperiencePoints = experiencePoints;

			Inventory = new List<InventoryItem>();
			Quest = new List<PlayerQuest>();
		}

		public bool HasRequiredItemToEnterLocation(Location location)
		{
			if (location.ItemRequiredToEnter == null)
			{
				return true;	
			}
			foreach (InventoryItem ii in Inventory)
			{
				if (ii.Details.ID == location.ItemRequiredToEnter.ID)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasThisQuest(Quest quest)
		{
			foreach (PlayerQuest playerQuest in Quest)
			{
				if (playerQuest.Details.ID == quest.ID)
				{
					return true;
				}
			}
			return false;
		}

		public bool CompletedThisQuest(Quest quest)
		{
			foreach (PlayerQuest playerQuest in Quest)
			{
				if (playerQuest.Details.ID == quest.ID)
				{
					return playerQuest.QuestCompleted;
				}
			}
			return false;
		}

		public bool HasAllQuestCompletionItems(Quest quest)
		{
			//see if player has all items needed
			foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
			{
				bool foundItemInPlayerInventory = false;

				foreach (InventoryItem x in Inventory)
				{
					if (x.Details.ID == qci.Details.ID)
					{
						foundItemInPlayerInventory = true;

						if (x.Quantity < qci.Quanity)
						{
							return false;
						}

					}
				}
				if (!foundItemInPlayerInventory)
				{
					return false;
				}
			}
			return true;

		}

		public void RemoveQuestCompletionItem(Quest quest)
		{
			// Remove quest items from inventory
			foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
			{
				foreach (InventoryItem ii in Inventory)
				{
					if (ii.Details.ID == qci.Details.ID)
					{
						// Subtract the quantity from the player's inventory that was needed to complete the quest
						ii.Quantity -= qci.Quanity;
						break;
					}
				}
			}
		}

		public void AddItemToInventory(Items itemToAdd)
		{
			foreach (InventoryItem x in Inventory)
			{
				if (x.Details.ID == itemToAdd.ID)
				{
					// They have the item in their inventory, so increase the quantity by one
					x.Quantity++;
					return;	
				}
			}
			Inventory.Add(new InventoryItem(itemToAdd, 1));
		}

		public void MarkQuestCompleted(Quest quest)
		{
			foreach (PlayerQuest pq in Quest)
			{
				if (pq.Details.ID == quest.ID)
				{
					pq.QuestCompleted = true;
					return;
				}
			}

		}
	}
}
