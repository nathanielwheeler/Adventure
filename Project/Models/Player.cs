using System.Collections.Generic;
using Adventure.Interfaces;

namespace Adventure.Models
{
	public class Player : IPlayer
	{
		public string Name { get; set; }
		public List<IKey> Keychain { get; set; }


		public Player(string name)
		{
			Name = "Nathan";
			Keychain = new List<IKey>();
		}
	}
}