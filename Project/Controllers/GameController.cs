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

		//NOTE this should print your messages for the game.
		private void Print()
		{
			Console.Clear();
			// This keeps the room description at the top of the console at all times.
			System.Console.WriteLine(_gameService.GetGameDetails());
			foreach (string m in _gameService.Messages)
			{
				System.Console.WriteLine(m);
			}
			_gameService.Messages.Clear();
		}

		//NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
		public void GetUserInput()
		{
			Console.Write("What would you like to do?\n > ");
			#region Command Parse
			string input = Console.ReadLine().ToLower() + " ";
			string command = input.Substring(0, input.IndexOf(" "));
			string option = input.Substring(input.IndexOf(" ") + 1).Trim();
			//NOTE this will take the user input and parse it into a command and option.
			//IE: take silver key => command = "take" option = "silver key"
			#endregion


			switch (command)
			{

				#region Character Actions

				case "look":
				case "ls":
				case "l":
					_gameService.Look(option);
					break;
				case "take":
					_gameService.TakeItem(option);
					break;
				case "use":
					_gameService.UseItem(option);
					break;
				case "inventory":
				case "i":
					_gameService.Inventory();
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
					_gameService.CheckConditional(command, option);//NOTE
					break;
					#endregion
			}
		}



	}
}