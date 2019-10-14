using System.Collections.Generic;
using Adventure.Models;

namespace Adventure.Interfaces
{
	public interface IPlayer
	{
		string Name { get; set; }
		List<IKey> Keychain { get; set; }
	}
}
