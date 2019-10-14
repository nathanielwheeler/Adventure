using System.Collections.Generic;
using Adventure.Interfaces;

namespace Adventure.Models
{
	public class Player : IPlayer
	{
		public string Name { get; set; }
		public List<Item> Inventory { get; set; }

		public Player(string name)
		{
			Name = name;
			Inventory = new List<Item>();
		}
	}
}