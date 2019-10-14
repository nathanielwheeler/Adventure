using System.Collections.Generic;

namespace Adventure.Interfaces
{
	public interface IRoom
	{
		string Name { get; set; }
		string Description { get; set; }
		List<IKey> Keys { get; set; }
		Dictionary<string, IRoom> Exits { get; set; }
		Dictionary<string, IRoom> ConditionalExits { get; set; }
		public bool Death { get; set; }
		public bool Victory { get; set; }

		IRoom Go(string destination);
		string GetTemplate();
	}
}
