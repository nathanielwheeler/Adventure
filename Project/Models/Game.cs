using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
	public class Game : IGame
	{
		public IRoom CurrentRoom { get; set; }
		public IPlayer CurrentPlayer { get; set; }

		//NOTE Make yo rooms here...
		public void Setup(int mode)
		{
			switch (mode)
			{
				case 0:
					SetupBasicGame();
					return;
				case 1:
					SetupCoolGame();
					return;
			}
		}

		public void SetupBasicGame()
		{
			//Room Initializations
			Room start = new Room(
				"The Hall of Journeys Yet To Begin",
				"You are in a room.  It feels like a good place to start."
			);
			Room middle = new Room(
				"The Middle",
				"You are in a room.  It feels meh."
			);
			Room lose = new Room(
				"The Room That Kills You When You Enter It",
				"You are in a room.  It feels like you've just lost the game.  Which you did."
			);
			Room win = new Room(
				"Destination: Victory",
				"You are in a room.  It feels like victory snatched from the grasp of a narcoleptic infant."
			);

			//Add Connections
			start.AddDoor("East", middle);
			middle.AddDoor("West", start);
			middle.AddDoor("North", lose);
			middle.AddDoor("South", win);
			win.AddDoor("North", middle);

			//TODO Create Items

			//Set starting point
			CurrentRoom = start;
		}
		public void SetupCoolGame()
		{
			SetupBasicGame();
		}







		public Game()
		{
			Setup(0);
		}
	}
}