using System;
using Adventure.Interfaces;

namespace Adventure.Controllers
{

	public class GameController : IGameController
	{
		private GameService _gameService { get; set; }
		public string PlayStatus { get; set; }

		//NOTE Makes sure everything is called to finish Setup and Starts the Game loop
		public void Run()
		{
			System.Console.Write("Enter name: ");
			string name = Console.ReadLine();
			_gameService.Setup(name);
			bool playing = true;
			while (playing)
			{
				playing = Play();
			}
			Console.Write("Would you like to play again? Y/N: ");
			bool parsingPrompt = true;
			while (parsingPrompt)
			{
				string response = Console.ReadLine().ToLower();
				switch (response)
				{
					case "y":
						System.Console.WriteLine("Bold of you to assume that I was able to figure out how to reset the game.");
						// _gameService.Reset();
						parsingPrompt = false;
						break;
					case "n":
						_gameService.Quit();
						parsingPrompt = false;
						break;
					default:
						Console.WriteLine("Invalid Input.");
						parsingPrompt = true;
						break;
				}

			}
			Environment.Exit(0);
		}

		private bool Play()
		{
			PlayStatus = _gameService.CheckPlayStatus();
			Print();
			if (PlayStatus == "win" || PlayStatus == "lose")
			{
				return false;
			}
			GetUserInput();
			return true;
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
					_gameService.Messages.Add($"I don't know '{command + " " + option}'");
					break;
					#endregion
			}
		}





		public GameController(string mode)
		{
			_gameService = new GameService(mode);
			PlayStatus = "";
		}
	}
}