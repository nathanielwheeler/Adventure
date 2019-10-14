using System.Collections.Generic;
using Adventure.Interfaces;

namespace Adventure.Models
{
	public class MazeRoom : IRoom
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List<IKey> Keys { get; set; }
		public Dictionary<string, IRoom> Exits { get; set; }
		public Dictionary<string, IRoom> ConditionalExits { get; set; }
		public bool Death { get; set; }
		public bool Victory { get; set; }

		public IRoom Go(string destination)
		{
			throw new System.NotImplementedException();
		}

		public string GetTemplate()
		{
			string template = "";
			template += $"You are in a triangular room.  {Description}\nEach exit has a number above it.  The exit numbers are ";
			foreach (var exit in Exits)
			{
				template += exit.Key;
			}
			foreach (var exit in ConditionalExits)
			{
				template += exit.Key + "(locked)";
			}
			return template;
		}

		public MazeRoom(string name, string description, bool death, bool victory)
		{
			Name = name;
			Description = description;
			Keys = new List<IKey>();
			Exits = new Dictionary<string, IRoom>();
			Death = death;
			Victory = victory;
		}

	}
}