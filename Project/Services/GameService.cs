using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
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
		public void Look(string option)
		{
			throw new System.NotImplementedException();
		}
		public void Inventory()
		{
			throw new System.NotImplementedException();
		}


		///<summary>
		///	When taking an item be sure the item is in the current room before adding it to the player inventory, 
		///	Also don't forget to remove the item from the room it was picked up in
		///</summary>
		public void TakeItem(string itemName)
		{
			//	Check if the item exists in the CurrentRoom
			//		If the item exists, remove it from current room and add it to the inventory
			Item target;
			for (int i = 0; i < _game.CurrentRoom.Items.Count; i++)
			{
				Item item = _game.CurrentRoom.Items[i];
				if (item.Name == itemName)
				{
					target = item;
					_game.CurrentPlayer.Inventory.Add(target);
					_game.CurrentRoom.Items.Remove(target);
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
		public void UseItem(string option)
		{
			string input = option + " ";
			string item = input.Substring(0, input.IndexOf(" "));
			string target = input.Substring(input.IndexOf(" ") + 1).Trim();
			_game.CurrentPlayer.Inventory.ForEach(i =>
			{
				if (i.Name == item)
				{
					//FIXME
					return;
				}
				else
				{
					Messages.Add("Uh, what?");
				}
			});
		}

		#endregion
		#region Game Actions

		public void Help()
		{
			throw new System.NotImplementedException();
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