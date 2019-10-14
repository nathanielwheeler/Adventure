using System;
using System.Collections.Generic;
using Adventure.Interfaces;

namespace Adventure.Models
{
	public class Room : IRoom
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List<IItem> Items { get; set; }
		public Dictionary<string, IRoom> Exits { get; set; }
		public Dictionary<string, IRoom> ConditionalExits { get; set; }
		public Dictionary<string, IConditional> Triggers { get; set; }


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
		public void AddConditionalExit(string exit, IRoom room)
		{
			ConditionalExits.Add(exit, room);
		}

		public void AddItem(IItem item)
		{
			Items.Add(item);
		}

		public string GetTemplate()
		{
			string template = $"\n\t{Name.ToUpper()}\n\n\t{Description}\n";

			foreach (var item in Items)
			{
				template += $"\tThere is a {item.Name.ToUpper()}.\n";
			}
			template += "Exits are:\n";
			foreach (var exit in Exits)
			{
				template += "\t\t- " + exit.Key.ToUpper() + "\n";
			}
			foreach (var exit in ConditionalExits)
			{
				template += "\t\t- " + exit.Key.ToUpper() + " (locked)\n";
			}
			return template;
		}

		public Room(string name, string description)
		{
			Name = name;
			Description = description;
			Items = new List<IItem>();
			Exits = new Dictionary<string, IRoom>();
			ConditionalExits = new Dictionary<string, IRoom>();
		}
	}
}