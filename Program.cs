using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Adventure;
using Adventure.Controllers;

namespace ConsoleAdventure
{
	public class Program
	{

		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();

		// TODO needs refactoring.  I need to think about how I need to run each game.
		// public static void Game(string[] args)
		// {

		// 	Console.Write("Choose a mode:\n\t- EASY mode\n\t- HARD mode (coming soon)\n> ");
		// 	string mode = "";
		// 	while (mode == "")
		// 	{
		// 		string modeParse = Console.ReadLine().ToLower();
		// 		switch (modeParse)
		// 		{
		// 			case "mvp":
		// 			case "easy":
		// 			case "easy mode":
		// 				mode = "mvp";
		// 				break;
		// 			case "maze":
		// 			case "hard":
		// 			case "hard mode":
		// 				mode = "maze";
		// 				break;
		// 			case "quit":
		// 				Environment.Exit(0);
		// 				break;
		// 			default:
		// 				System.Console.WriteLine("That's not a game mode, but I wish it was.");
		// 				break;
		// 		}
		// 	}
		// 	GameController gameController = new GameController(mode);
		// 	gameController.Run();

		// }
	}
}
