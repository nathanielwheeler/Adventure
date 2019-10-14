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
                                                                              
                                                                              
MMMMMMMM               MMMMMMMMVVVVVVVV           VVVVVVVVPPPPPPPPPPPPPPPPP   
M:::::::M             M:::::::MV::::::V           V::::::VP::::::::::::::::P  
M::::::::M           M::::::::MV::::::V           V::::::VP::::::PPPPPP:::::P 
M:::::::::M         M:::::::::MV::::::V           V::::::VPP:::::P     P:::::P
M::::::::::M       M::::::::::M V:::::V           V:::::V   P::::P     P:::::P
M:::::::::::M     M:::::::::::M  V:::::V         V:::::V    P::::P     P:::::P
M:::::::M::::M   M::::M:::::::M   V:::::V       V:::::V     P::::PPPPPP:::::P 
M::::::M M::::M M::::M M::::::M    V:::::V     V:::::V      P:::::::::::::PP  
M::::::M  M::::M::::M  M::::::M     V:::::V   V:::::V       P::::PPPPPPPPP    
M::::::M   M:::::::M   M::::::M      V:::::V V:::::V        P::::P            
M::::::M    M:::::M    M::::::M       V:::::V:::::V         P::::P            
M::::::M     MMMMM     M::::::M        V:::::::::V          P::::P            
M::::::M               M::::::M         V:::::::V         PP::::::PP          
M::::::M               M::::::M          V:::::V          P::::::::P          
M::::::M               M::::::M           V:::V           P::::::::P          
MMMMMMMM               MMMMMMMM            VVV            PPPPPPPPPP          
                                                                              
                                                                              
                                                                              
                                                                              
                                                                              
                                                                              
                                                                              
			");
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
