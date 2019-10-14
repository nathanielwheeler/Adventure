using System;
using Adventure.Interfaces;

namespace Adventure.Controllers
{

	public class GameController : IGameController
	{
		private GameService _gameService { get; set; }

		//NOTE Makes sure everything is called to finish Setup and Starts the Game loop
		public void Run()
		{
			bool playing = true;
			while (playing)
			{
				playing = Play();
			}

		}

		private bool Play()
		{
			Print();
			GetUserInput();
			return _gameService.CheckPlayStatus();
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
			Console.Write("> ");
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
				case "get":
				case "take":
					_gameService.TakeItem(option);
					break;
				case "use":
					switch (option)
					{
						case "key":
							_gameService.UseKey(option);
							break;
						default:
							_gameService.Messages.Add("You don't have that.");
							break;
					}
					break;
				case "inventory":
				case "inv":
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
					_gameService.Messages.Add("Uh, what?");
					break;
					#endregion
			}
		}





		public GameController(string mode)
		{
			_gameService = new GameService(mode);
		}
	}
}