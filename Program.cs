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

			Console.Write("Choose a mode:\n\t- EASY mode\n\t- HARD mode (coming soon)\n> ");
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
					case "quit":
						Environment.Exit(0);
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
