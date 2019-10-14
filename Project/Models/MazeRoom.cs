using System.Collections.Generic;
using Adventure.Interfaces;

namespace Adventure.Models
{
	public class MazeRoom : IRoom
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List<IItem> Items { get; set; }
		public Dictionary<string, IRoom> Exits { get; set; }
		public Dictionary<string, IConditional> Triggers { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public IRoom Go(string destination)
		{
			throw new System.NotImplementedException();
		}
		public bool IsLocked(string destination)
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
			Items = new List<IItem>();
			Exits = new Dictionary<string, IRoom>();
		}

	}
}