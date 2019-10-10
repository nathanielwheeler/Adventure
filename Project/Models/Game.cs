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
				"Purgatory",
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
			Room dennis = new Room(
				"Dennis",
				"Ye arrive at Dennis. He wears a sporty frock coat and a long jimberjam. He paces about nervously. Obvious exits are NOT DENNIS."
			);

			//Add Connections
			start.AddDoor("EAST", middle);
			middle.AddDoor("WEST", start);
			middle.AddDoor("NORTH", lose);
			middle.AddDoor("SOUTH", win);
			middle.AddDoor("DENNIS", dennis);
			win.AddDoor("NORTH", middle);
			dennis.AddDoor("NOT DENNIS", dennis);


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