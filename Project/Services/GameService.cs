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



		#region Directional Action
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

		// public void Fly(string airportCode)
		// {
		// 	//change destination
		// 	string from = _game.CurrentAirport.Name;
		// 	_game.CurrentAirport = _game.CurrentAirport.Fly(airportCode);
		// 	string to = _game.CurrentAirport.Name;

		// 	//If failed to go anywhere, stop code execution
		// 	if (from == to)
		// 	{
		// 		Messages.Add("Invalid Destination");
		// 		return;
		// 	}
		// 	Messages.Add($"Traveled from {from} to {to}");
		// 	UnloadCargo();
		// 	LoadCargo();
		// }

		#endregion
		#region Character Actions

		public void Inventory()
		{
			throw new System.NotImplementedException();
		}

		public void Look()
		{
			throw new System.NotImplementedException();
		}

		///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
		public void TakeItem(string itemName)
		{
			throw new System.NotImplementedException();
		}
		///<summary>
		///No need to Pass a room since Items can only be used in the CurrentRoom
		///Make sure you validate the item is in the room or player inventory before
		///being able to use the item
		///</summary>
		public void UseItem(string itemName)
		{
			throw new System.NotImplementedException();
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