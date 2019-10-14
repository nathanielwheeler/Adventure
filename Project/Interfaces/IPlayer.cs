using System.Collections.Generic;
using Adventure.Models;

namespace Adventure.Interfaces
{
	public interface IPlayer
	{
		string Name { get; set; }
		List<Item> Inventory { get; set; }
	}
}
