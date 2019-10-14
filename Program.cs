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
			Thread.Sleep(750);
			new GameController().Run();
		}
	}
}
