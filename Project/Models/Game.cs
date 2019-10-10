using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
	public class Game : IGame
	{
		public IRoom CurrentRoom { get; set; }
		public IPlayer CurrentPlayer { get; set; }


		//NOTE Make yo rooms here...
		public void Setup(string mode)
		{
			switch (mode)
			{
				case "mvp":
					SetupMVP();
					return;
				case "maze":
					SetupMaze();
					return;
			}
		}
		internal void SetupMVP()
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
				"Ye arrive at Dennis. He wears a sporty frock coat and a long jimberjam. He paces about nervously."
			);

			//Add Connections
			start.AddExit("EAST", middle);
			middle.AddExit("WEST", start);
			middle.AddExit("NORTH", lose);
			middle.AddExit("SOUTH", win);
			middle.AddExit("DENNIS", dennis);
			win.AddExit("NORTH", middle);
			dennis.AddExit("NOT DENNIS", dennis);



			//TODO Create Items

			//Set starting point
			CurrentRoom = start;
		}
		internal void SetupMaze()
		{
			Setup("mvp");
		}







		public Game()
		{
			Setup("mvp");
		}
	}
}