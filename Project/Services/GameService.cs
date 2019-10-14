using System;
using System.Collections.Generic;
using Adventure.Interfaces;
using Adventure.Models;

namespace Adventure
{
	public class GameService : IGameService
	{
		private IGame _game { get; set; }

		public List<string> Messages { get; set; }

		public string GetGameDetails()
		{
			return _game.CurrentRoom.GetTemplate();
		}




		#region Player Actions

		///<summary>
		///This method checks if the user's input returns true on any conditional actions.
		///</summary>
		public void CheckConditional(string command, string option)
		{
			//Check game conditionals
			//Check room conditionals
			//If nothing matches, notify user
		}

		public void Go(string direction)
		{
			//change destination

			string from = _game.CurrentRoom.Name;
			_game.CurrentRoom = _game.CurrentRoom.Go(direction);
			string to = _game.CurrentRoom.Name;
			//if failed to go anywhere, stop code execution
			if (from == to)
			{
				Messages.Add("You can't do that.");
			}

		}
		public void Look(string target)
		{
			for (int i = 0; i < _game.CurrentRoom.Keys.Count; i++)
			{
				IKey item = _game.CurrentRoom.Keys[i];
				if (target == item.Name)
				{
					string description = item.GetDescription();
					Messages.Add(description);
					return;
				}
			}
		}
		public void Inventory()
		{
			List<IKey> keychain = _game.CurrentPlayer.Keychain;
			Messages.Add("Inventory:");
			if (keychain.Count > 0)
			{
				keychain.ForEach(item => Messages.Add("\t- " + item.Name.ToUpper()));
			}
			else
			{
				Messages.Add("Your inventory is empty.");
			}
		}


		///<summary>
		///	When taking an item be sure the item is in the current room before adding it to the player inventory, 
		///	Also don't forget to remove the item from the room it was picked up in
		///</summary>
		public void TakeItem(string itemName)
		{
			//	Check if the item exists in the CurrentRoom
			//		If the item exists, remove it from current room and add it to the inventory
			IKey target;
			for (int i = 0; i < _game.CurrentRoom.Keys.Count; i++)
			{
				IKey item = _game.CurrentRoom.Keys[i];
				if (item.Name == itemName)
				{
					target = item;
					_game.CurrentPlayer.Keychain.Add(target);
					_game.CurrentRoom.Keys.Remove(target);
					Messages.Add($"You got a {item.Name.ToUpper()}!");
					return;
				}
			}
			Messages.Add($"There is no '{itemName}' to get.");
		}

		///<summary>
		///No need to Pass a room since Items can only be used in the CurrentRoom
		///Make sure you validate the item is in the room or player inventory before
		///being able to use the item
		///</summary>
		public void UseKey(string option)
		{
			bool validLocation = false;
			//Check if key is in inventory
			_game.CurrentPlayer.Keychain.ForEach(key =>
			{
				int i = _game.CurrentPlayer.Keychain.IndexOf(key);
				IRoom room = _game.CurrentRoom;
				if (room.Exits.ContainsValue(key.TargetDestination))
				{
					Messages.Add("You already unlocked that.");
					validLocation = true;
					return;
				}
				else if (key.Name == option && room == key.ValidRoom)
				{
					IRoom destination = key.TargetDestination;
					room.Exits.Add(key.TargetDirection, key.TargetDestination);
					room.ConditionalExits.Remove(key.TargetDirection);
					Messages.Add("Unlocked exit!");
					validLocation = true;
					return;
				}
			});
			if (!validLocation)
			{
				Messages.Add("No applicable key.");
			}
		}

		#endregion
		#region Game Actions

		public void Help()
		{
			Messages.Add(@"Commands:
	GO to move in a direction
	LOOK to get something's description
	GET to add an item to your inventory
	USE to utilize an item in your inventory
	INVENTORY to look at what's in your inventory
	QUIT to exit the game");
		}

		public void Quit()
		{
			//TODO Call some sort of confirmation method
			Environment.Exit(0);
		}
		///<summary>
		///Restarts the game 
		///</summary>
		public void Reset()
		{
			//TODO Call some sort of confirmation method
			throw new System.NotImplementedException();
		}

		public void Setup(string playerName)
		{
			_game.CurrentPlayer = new Player(playerName);
		}

		#endregion






		public GameService()
		{
			_game = new Game();
			Messages = new List<string>();
		}
	}
}