using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdeventure.Properties;
using ClassLibrary1;
using ClassLibrary1.Locations;
using ClassLibrary1.Monsters.Quest;
using ClassLibrary1.Potions.Items.Weapons;


namespace TextAdeventure
{
	public partial class TextAdventure : Form
	{
		private Player player;
		private Monster currentMonster;

		public TextAdventure()
		{
			InitializeComponent();
			//add player things here
			player = new Player(10, 10, 20, 0, 1);
			MoveTo(World.LocationbyID(World.idHome));
			player.Inventory.Add(new InventoryItem(World.ItemByID(World.knife), 1));




			// making the states go to the labels
			lblHitPoints.Text = player.CurrentHP.ToString();
			lblGold.Text = player.Gold.ToString();
			lblLevel.Text = player.Level.ToString();
			lblExperience.Text = player.ExperiencePoints.ToString();

			//Location 
			//Location test1 = new Location(1, "Home", "This is your house");
			//Location location = new Location(1, "Home", "This is your house", null, null, null);



		}

		private void MoveTo(Location newLocation)
		{
			if (newLocation.ItemRequiredToEnter != null)
			{
				bool playerHasItem = false;
				foreach (InventoryItem i in player.Inventory)
				{
					if (i.Details.ID == newLocation.ItemRequiredToEnter.ID)
					{
						playerHasItem = true;
						break;
					}

				}
				if (!playerHasItem)
				{
					rtbMessages.Text += "You need a" + newLocation.ItemRequiredToEnter.Name + "to enter this location." + Environment.NewLine;
					return;
				}
			}
			//update players location
			player.CurrentLocation = newLocation;

			//show/hide availble movement buttons
			btnNorth.Visible = (newLocation.LocationNorth != null);
			btnEast.Visible = (newLocation.LocationEast != null);
			btnSouth.Visible = (newLocation.LocationSouth != null);
			btnWest.Visible = (newLocation.LocationWest != null);

			//display current location name and discription 
			rtbLocation.Text = newLocation.Name + Environment.NewLine;
			rtbLocation.Text = newLocation.Description + Environment.NewLine;

			//completely heal the player
			player.CurrentHP = player.MaxHP;

			//update player HP in UI
			lblHitPoints.Text = player.CurrentHP.ToString();

			//does location have a quest
			if (newLocation.QuestAvailableHere != null)
			{
				bool playerAlreadyHasQuest = false;
				bool playerAlreadyCompletedQuest = false;

				foreach (PlayerQuest playerquest in player.Quest)
				{
					if (playerquest.Details.ID == newLocation.QuestAvailableHere.ID)
					{
						playerAlreadyHasQuest = true;
						if (playerquest.QuestCompleted)
						{
							playerAlreadyCompletedQuest = true;
						}
					}
				}

				//see if player already has quest
				if (playerAlreadyHasQuest)
				{
					if (!playerAlreadyCompletedQuest)
					{
						bool playerHasAllItemsToCompleteQuest = true;

						foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
						{
							bool foundItemInPlayerInventory = false;

							foreach (InventoryItem x in player.Inventory)
							{
								if (x.Details.ID == qci.Details.ID)
								{
									foundItemInPlayerInventory = true;

									if (x.Quantity < qci.Quanity)
									{
										playerHasAllItemsToCompleteQuest = false;
										break;
									}
									break;
								}
							}

							// If we didn't find the required item, set our variable and stop looking for other items

							if (!foundItemInPlayerInventory)
							{
								playerHasAllItemsToCompleteQuest = false;
								break;
							}
						}

						// The player has all items required to complete the quest
						if (playerHasAllItemsToCompleteQuest)
						{
							// Display message
							rtbMessages.Text += Environment.NewLine;
							rtbMessages.Text += "you completed the" + newLocation.QuestAvailableHere.Name + " quest" + Environment.NewLine;
							// Remove quest items from inventory
							foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
							{
								foreach (InventoryItem ii in player.Inventory)
								{
									// Subtract the quantity from the player's inventory that was needed to complete the quest
									ii.Quantity -= qci.Quanity;
									break;
								}
							}
						}
						// Give quest rewards
						rtbMessages.Text = "You recieve:" + Environment.NewLine;
						rtbMessages.Text = newLocation.QuestAvailableHere.RewardEXP.ToString() + "EXP" + Environment.NewLine;
						rtbMessages.Text = newLocation.QuestAvailableHere.RewardGold.ToString() + " pieces of gold" + Environment.NewLine;
						rtbMessages.Text = newLocation.QuestAvailableHere.RewardItem.ToString() + Environment.NewLine;
						rtbMessages.Text = Environment.NewLine;

						// Add the reward item to the player's inventory
						bool playerGivenRewardItem = false;

						foreach (InventoryItem x in player.Inventory)
						{
							if (x.Details.ID == newLocation.QuestAvailableHere.RewardItem.ID)
							{
								// They have the item in their inventory, so increase the quantity by one
								x.Quantity++;
								playerGivenRewardItem = true;
								break;
							}
						}
						// They didn't have the item, so add it to their inventory, with a quantity of 1
						if (!playerGivenRewardItem)
						{
							player.Inventory.Add(new InventoryItem(newLocation.QuestAvailableHere.RewardItem, 1));
						}
						// Mark the quest as completed
						// Find the quest in the player's quest list
						foreach (PlayerQuest pq in player.Quest)
						{
							if (pq.Details.ID == newLocation.QuestAvailableHere.ID)
							{
								pq.QuestCompleted = true;
								break;
							}
						}
					}
				}

			}
			else
			{
				// The player does not already have the quest
				// Display the messages
				rtbMessages.Text += "Quest " + newLocation.QuestAvailableHere.Name + " has been added to your adventure" + Environment.NewLine;
				rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
				rtbMessages.Text += "To complete quest, return with " + Environment.NewLine;

				//foreach loop to run through questcompletionitems in newlocation
				foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
				{
					//if qci quanity = 1, rtbmessage(qci quanity and details)
					if (qci.Quanity == 1)
					{
						rtbMessages.Text += qci.Quanity.ToString() + " " + qci.Details.Name + Environment.NewLine;
					}
					else
					{
						//else (qci quanity + plural)
						rtbMessages.Text += qci.Quanity.ToString() + " " + qci.Details.PluralName + Environment.NewLine;
					}
				}
				rtbMessages.Text += Environment.NewLine;
				// Add the quest to the player's quest list
				player.Quest.Add(new PlayerQuest(newLocation.QuestAvailableHere, false));
			}
			// Is there a monster at the location?

		//	If so,
		//		Display message
		//		Spawn new monster to fight
		// Make a new monster, using the values from the standard monster in the World.Monster list
		//		Display combat comboboxes and buttons
		//		Repopulate comboboxes, in case inventory changed
		//	If not
		//		Hide combat comboboxes and buttons

		}


	}


	private void TextAdventure_Load(object sender, EventArgs e)
	{

	}

	private void label5_Click(object sender, EventArgs e)
	{

	}

	private void btnNorth_Click(object sender, EventArgs e)
	{

	}

	private void btnWest_Click(object sender, EventArgs e)
	{

	}

	private void btnEast_Click(object sender, EventArgs e)
	{

	}

	private void btnSouth_Click(object sender, EventArgs e)
	{

	}

	private void btnUseWeapon_Click(object sender, EventArgs e)
	{

	}

	private void btnUsePotion_Click_1(object sender, EventArgs e)
	{

	}
}

