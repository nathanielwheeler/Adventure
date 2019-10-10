using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

	public class GameController : IGameController
	{
		private GameService _gameService = new GameService();

		//NOTE Makes sure everything is called to finish Setup and Starts the Game loop
		public void Run()
		{
			System.Console.Write("Enter your name > ");
			_gameService.Setup(Console.ReadLine());
			while (true)
			{
				Print();
				GetUserInput();
			}
		}

		//NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
		public void GetUserInput()
		{
			Console.Write("What would you like to do?\n > ");
			string input = Console.ReadLine().ToLower() + " ";
			string command = input.Substring(0, input.IndexOf(" "));
			string option = input.Substring(input.IndexOf(" ") + 1).Trim();
			//NOTE this will take the user input and parse it into a command and option.
			//IE: take silver key => command = "take" option = "silver key"
			switch (command)
			{
				#region Character Actions
				case "inventory":
				case "i":
					_gameService.Inventory();
					break;
				case "look":
				case "ls":
				case "l":
					_gameService.Look();
					break;
				#endregion
				#region Game Actions
				case "help":
				case "h":
					_gameService.Help();
					break;
				case "q":
				case "quit":
				case "exit":
				case "close":
					_gameService.Quit();
					break;
				case "reset":
				case "r":
					_gameService.Reset();
					break;
				#endregion
				#region Directional Actions
				case "go":
				case "cd":
					_gameService.Go(option);
					break;
				default:
					_gameService.Go(command);
					break;
					// case "north":
					// case "n":
					// 	_gameService.Go("north");
					// 	break;
					// case "east":
					// case "e":
					// 	_gameService.Go("east");
					// 	break;
					// case "south":
					// case "s":
					// 	_gameService.Go("south");
					// 	break;
					// case "west":
					// case "w":
					// 	_gameService.Go("west");
					// 	break;
					#endregion

			}
		}

		//NOTE this should print your messages for the game.
		private void Print()
		{
			Console.Clear();
			System.Console.WriteLine(_gameService.GetGameDetails());

			foreach (string m in _gameService.Messages)
			{
				System.Console.WriteLine(m);
			}
			_gameService.Messages.Clear();
		}

	}
}