using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace Adventure.Project.Models
{
	public class MazeRoom : IRoom
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Item> Items { get; set; }
		public Dictionary<string, IRoom> Exits { get; set; }

		public IRoom Go(string destination)
		{
			throw new System.NotImplementedException();
		}

		public string GetTemplate()
		{
			string exits = "";
			foreach (var exit in Exits)
			{
				exits += "\t" + exit.Value.Name + "\n";
			}
			string template = $"{Name}\n\n{Description}\n\nThere are three doors labelled:\n{exits}";
			return template;
		}

		public MazeRoom(string name, string description)
		{
			Name = name;
			Description = description;
			Items = new List<Item>();
			Exits = new Dictionary<string, IRoom>();
		}

	}
}