using System;
using System.Threading;
using Adventure;
using Adventure.Controllers;

namespace ConsoleAdventure
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.Clear();
			System.Console.WriteLine(@"
	 _____         _   ___  ___          _            
	|_   _|       | |  |  \/  |         | |           
	  | | __ _ ___| | _| .  . | __ _ ___| |_ ___ _ __ 
	  | |/ _` / __| |/ / |\/| |/ _` / __| __/ _ \ '__|
	  | | (_| \__ \   <| |  | | (_| \__ \ ||  __/ |   
	  \_/\__,_|___/_|\_\_|  |_/\__,_|___/\__\___|_|   
	
	
			");
			Console.Write("Choose a mode:\n\t- EASY mode\n\t- HARD mode\n> ");
			string mode = "";
			while (mode == "")
			{
				string modeParse = Console.ReadLine().ToLower();
				switch (modeParse)
				{
					case "mvp":
					case "easy":
					case "easy mode":
						mode = "mvp";
						break;
					case "maze":
					case "hard":
					case "hard mode":
						mode = "maze";
						break;
					default:
						System.Console.WriteLine("That's not a game mode, but I wish it was.");
						break;
				}
			}
			GameController gameController = new GameController(mode);
			gameController.Run();

		}
	}
}
