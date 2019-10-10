using ConsoleAdventure.Project.Interfaces;

namespace Adventure.Project.Models

{
	public class Menu : IGame
	{
		public IRoom CurrentRoom { get; set; }
		public IPlayer CurrentPlayer { get; set; }

		public void Setup(string mode)
		{
			throw new System.NotImplementedException();
		}
	}
}