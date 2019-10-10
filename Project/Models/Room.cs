using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
	public class Room : IRoom
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Item> Items { get; set; }
		public Dictionary<string, IRoom> Exits { get; set; }
		//TODO make a dictionary or list that can reference a conditional action command in this room.


		public IRoom Go(string destination)
		{
			if (Exits.ContainsKey(destination))
			{
				return Exits[destination];
			}
			return this;
		}


		public void AddExit(string exit, IRoom room)
		{
			Exits.Add(exit, room);
		}

		public string GetTemplate()
		{
			string template = $"\n\t{Name.ToUpper()}\n\n\t{Description}\n\n";
			if (Exits.Count > 0)
			{
				template += "\tObvious exits are:\n";
				foreach (var exit in Exits)
				{
					template += "\t\t" + exit.Key.ToUpper() + "\n";
				}
			}
			return template;
		}

		public Room(string name, string description)
		{
			Name = name;
			Description = description;
			Items = new List<Item>();
			Exits = new Dictionary<string, IRoom>();
		}
	}
}