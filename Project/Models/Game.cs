using Adventure.Interfaces;

namespace Adventure.Models
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
					// SetupMaze();
					return;
			}
		}
		internal void SetupMVP()
		{
			//Room Initializations
			Room start = new Room(
				"The Hall of Journeys Yet To Begin",
				"You are in a room.  It feels like a good place to start.",
				false,
				false
			);
			Room middle = new Room(
				"Crossroad",
				"You are in a room.  There is a sign that says 'Don't go North!'",
				false,
				false
			);
			Room lose = new Room(
				"The Room That Kills You When You Enter It",
				"You are in a room.  It feels like you've just lost the game.  Which you did.",
				true,
				false
			);
			Room win = new Room(
				"Destination: Victory",
				"You are in a room.  Oh hey, it seems you found what you needed, whatever that was.",
				false,
				true
			);

			//Add Connections
			start.AddConditionalExit("east", middle);
			middle.AddExit("west", start);
			middle.AddExit("north", lose);
			middle.AddExit("south", win);


			//Create Items
			IKey key = new Key("key", "It's a headscratcher as to where this key goes to.", "east", middle, start);

			//Place Items in Rooms
			start.AddKey(key);

			//Set starting point
			CurrentRoom = start;
		}

		// internal void SetupMaze()
		// {
		// 	//Room Initializations
		// 	MazeRoom 
		// 	//Add Connections

		// 	//Set starting point


		// }








		public Game(string mode)
		{
			Setup(mode);
		}
	}
}